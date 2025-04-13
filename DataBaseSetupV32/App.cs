using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options; 
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using LanguageResource;
using System.Diagnostics;
using System.Globalization;
using Caching; 
using Microsoft.AspNetCore.Identity;
using DataBaseSetupV3.Data;
using System.Linq;
using DataBaseSetupV3.Model; 
using Newtonsoft.Json;
using System.IO;
using DataBaseSetupV3.Context;

namespace DataBaseSetupV3
{
    public class App
    {
        private static ILogger<App> _logger; 
        private static string _CONNECTION_STRING;
        private static List<SystemUser> _systemUserList;
        private UserManager<IdentityUser> _userManager;
     
        public static readonly FIFOCache<string, byte[]> cache = RunTimeCache.FIFOCache();

        public App( ILogger<App> logger, IOptions<List<SystemUser>> systemUserList, UserManager<IdentityUser> userManager)
        {
            string CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
            _CONNECTION_STRING = CONNECTION_STRING;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _systemUserList = systemUserList?.Value ?? throw new ArgumentNullException(nameof(systemUserList));

            _userManager = userManager;
        }
         
        public void Run(string languageCode)
        { 
            #region BEGIN
            //==============================================================================================================================
            Console.WriteLine("[APP RUN][=========================================================================================================]");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.Title = "DATABASE SEED BATCH DATA";
            
            ////-------------------------------------------------------------
            _logger.LogInformation("[SYSTEM USER]\n");
            InistializeData1.MainComId = SystemData.CreateMainComId();
            InistializeData1.IndustryId = SystemData.GetIndustryId();
            int userCount = SystemUserInitialize(_userManager, _systemUserList, InistializeData1.MainComId, InistializeData1.IndustryId);
            _logger.LogInformation("[SYSTEM USER COUNT = {0}]\n", userCount);
             
            //end
            string time = sw.Elapsed + "(" + sw.Elapsed.Seconds + "s" + sw.Elapsed.Milliseconds + "ms)";
            Console.WriteLine(">>>APP RUN FINISHED Elapsed Time = {0}", sw.Elapsed);
            sw.Stop();
            //await Task.CompletedTask;
            _logger.LogInformation("APP RUN FINISHED!");
             
            #endregion END 
        }

        #region  [SystemUser snippet] 

        public static int SystemUserInitialize(UserManager<IdentityUser> userManager, List<SystemUser> systemUserList, string mainComId, string industryId)
        {
            int intResult = 0;
            if (systemUserList.Count() > 0)
            {
                foreach (var item in systemUserList)
                {
                    var userPassword = GenerateSecurePassword();
                    var userId = EnsureUser(userManager, item.UserName, item.Email, userPassword, mainComId, industryId);

                    //UserRoleInitialize.UserRoleSystemAdminAsigned(userId);  // User Add roles  已经之前处理.无须再次运行

                    //DEBUG 无法更新 MainComId 和 IndustryId
                    //bool updMainIdIndustryId = UpdateMainComAndIndustry(userId, mainComId, industryId); 
                    //_logger.LogInformation("[{0:F}][FUNC::UpdateMainComAndIndustry()] [RESULT] [{1}]", DateTime.Now, updMainIdIndustryId);

                    intResult++;
                    EmailNotifyUser(item.Email, userPassword);
                }
            }
            else
            {
                _logger.LogInformation("[{0:F}][_SYSTEMUSERLIST (FROM APPSETTING.JSON) NO RECORD ]", DateTime.Now);
            }
            return intResult;
        }

        private static string EnsureUser(UserManager<IdentityUser> userManager,string userName, string email, string userPassword, string mainComId, string industryId)
        {
            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();

            if (user == null)
            {
                user = new IdentityUser
                {
                    Id = string.Format("{0}{1}", SystemData.CreateSupervisorId(), DateTime.Now.Millisecond),  //revised in 2022-1-18 //old: Id = string.Format("{0}{1}", SystemData.CreateSupervisorId(), DateTime.Now.Millisecond),   //NEW 2022-1-18 : Id = string.Format("{0}{1}{2}{3}", DateTime.Now.Month, DateTime.Now.Day, (int)DateTime.Now.DayOfWeek, DateTime.Now.Millisecond),
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                IdentityResult identityResult = userManager.CreateAsync(user, userPassword).GetAwaiter().GetResult();
                if (identityResult.Succeeded)
                { 
                    //有问题,移除外面处理 Debug, Move to Outside
                    //bool updMandI = UpdateMainComAndIndustry(user.Id, mainComId, industryId);
                    //Console.WriteLine("\n[NEW SYSTEM USER] UserName = {0} Password = {1} [UPDATE MAINCOM AND INDUSTRY = {2}]\n\n", email, userPassword, updMandI);

                    bool rn = AdministratorRolesAdd(userManager, user);
                    if (rn)
                        Console.WriteLine("\n[ROLES ALL SUCCESS {0}]\n", rn);
                    else
                        UserRoleInitialize.UserRoleSystemAdminAsigned(user.Id);  // User Add roles

                    string fileName = string.Format("AccountOfAdmin{0}.TXT", user.Id);
                    string identityResultText = $"SUCCESS PLEASE REMEMBER [WRITE DOWN TO FOLDER ./ACCOUNT] [SAVE TO THE ROOT AS FILE:{fileName}]: \nUser Id={user.Id} Email = {user.Email}, Password = {GenerateSecurePassword()},  MainComId (CompanyId) = {SystemData.CreateMainComId()}";
                    string accountPathFile = Path.Combine(Directory.GetCurrentDirectory(),"ACCOUNT", fileName);
                    // 提取目录路径
                    string directoryPath = Path.GetDirectoryName(accountPathFile);

                    // 检查目录是否存在，若不存在则创建
                    if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    bool IsSave = SaveDataJson(identityResultText, accountPathFile);
                    if (IsSave)
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        Console.WriteLine("\n[ACCOUNT OF ADMIN HAS SAVED]  [{0} [{1}]]\n\n", IsSave, accountPathFile);
                        Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\n[CREATE SYSTEM USER]  UserName = {0}  email = {1} [FAIL]", userName,email);
                }
            }
            return user.Id;
        }

        public static bool AdministratorRolesAdd(UserManager<IdentityUser> userManager, IdentityUser userRaw)
        {
            var user = userManager.FindByIdAsync(userRaw.Id).Result;

            bool userRolesResult = false;
           
            try
            {
                var taskResult1 = userManager.AddToRoleAsync(user, RoleConst.SYSTEM_ADMIN.ToUpper());
                if (taskResult1.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.SYSTEM_ADMIN.ToUpper());
                }

                var taskResult2 = userManager.AddToRoleAsync(user, RoleConst.ADMIN.ToUpper());
                if (taskResult2.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.ADMIN.ToUpper());
                }

                var taskResult3 = userManager.AddToRoleAsync(user, RoleConst.SYSTEM_OPERATOR.ToUpper());
                if (taskResult3.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.SYSTEM_OPERATOR.ToUpper());
                }

                var taskResult4 = userManager.AddToRoleAsync(user, RoleConst.MAINCOM_OPERATOR.ToUpper());
                if (taskResult4.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.MAINCOM_OPERATOR.ToUpper());
                }

                var taskResult5 = userManager.AddToRoleAsync(user, RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR.ToUpper());
                if (taskResult5.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR.ToUpper());
                }

                var taskResult6 = userManager.AddToRoleAsync(user, RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN.ToUpper());
                if (taskResult6.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN.ToUpper());
                }

                var taskResult7 = userManager.AddToRoleAsync(user, RoleConst.EMPLOYEE.ToUpper());
                if (taskResult7.Result.Succeeded)
                {
                    _logger.LogInformation("\n[{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.EMPLOYEE.ToUpper());
                }

                var taskResult8 = userManager.AddToRoleAsync(user, RoleConst.LRO.ToUpper());
                if (taskResult8.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.LRO.ToUpper());
                }

                var taskResult9 = userManager.AddToRoleAsync(user, RoleConst.GUEST.ToUpper());
                if (taskResult9.Result.Succeeded)
                {
                    _logger.LogInformation("\n[USER ROLES][{0}]  [{1} [ROLE] = [{2}] \n", user.Email, user.UserName, RoleConst.GUEST.ToUpper());
                }

                bool r1 = taskResult1.Result.Succeeded;
                bool r2 = taskResult2.Result.Succeeded;
                bool r3 = taskResult3.Result.Succeeded;
                bool r4 = taskResult4.Result.Succeeded;
                bool r5 = taskResult5.Result.Succeeded;
                bool r6 = taskResult6.Result.Succeeded;
                bool r7 = taskResult7.Result.Succeeded;
                bool r8 = taskResult8.Result.Succeeded;
                bool r9 = taskResult9.Result.Succeeded;
                userRolesResult = r1 && r2 && r3 && r4 && r5 && r6 && r7 && r8 && r9;
            }
            catch (Exception e)
            {
                _logger.LogInformation("\n[CREATE USER ROLES] [EXCEPTION]  [FAIL] [{0}]\n", e.Message);
                return false;
            }

            return userRolesResult;
        }

        public static bool UpdateMainComAndIndustry(string userId, string mainComId, string industryId)
        {
            bool resMainComId = UpdateMainComId(userId, mainComId);
            bool resIndustryId = UpdateMainComId(userId, industryId);

            return resMainComId == true && resIndustryId == true;
        }

        public static bool UpdateMainComId(string userId, string mainComId)
        { 
            try
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    var user = dataBaseContext.AspNetUsers.Find(userId);
                    user.MainComId = mainComId;
                    dataBaseContext.Attach(user);
                    dataBaseContext.Entry(user).Property(o => o.MainComId).IsModified = true;
                    bool result = dataBaseContext.SaveChanges() > 0;

                    string logline = $"[UPDATE MAINCOM ID]  [SUCCESS = {result.ToString().ToUpper()}] [MainComId={mainComId}]\n";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, logline);
                    Console.ResetColor();

                    return true;
                } 
            }
            catch
            {
                string exLog = $"[UPDATE MAINCOM ID]  [FAIL] [MainComId={mainComId}]\n";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, exLog);
                Console.ResetColor();
                _logger.LogError(exLog);
                return false;
            }
        }

        public static bool UpdateIndustryId(string userId, string industryId)
        {
            try
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    var user = dataBaseContext.AspNetUsers.Find(userId);
                    user.IndustryId = industryId;
                    dataBaseContext.Attach(user);
                    dataBaseContext.Entry(user).Property(o => o.IndustryId).IsModified = true;
                    bool result = dataBaseContext.SaveChanges() > 0;

                    string logline = $"[UPDATE INDUSTRY ID]  [SUCCESS = {result.ToString().ToUpper()}] [IndustryId={industryId}]\n";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, logline);
                    Console.ResetColor();

                    return true;
                }
            }
            catch
            {
                string exLog = $"[UPDATE INDUSTRY ID]  [FAIL] [IndustryId={industryId}]\n";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, exLog);
                Console.ResetColor();
                _logger.LogError(exLog);
                return false;
            }
        }

        public static bool SaveDataJson(string FileContent, string PathFile)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(PathFile, false, System.Text.Encoding.GetEncoding("UTF-8"));
                writer.Write(FileContent);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

            return true;
        }
        private static string GenerateSecurePassword()
        {
            // Generate a secure password
            return "admin888";
        }
        private static void EmailNotifyUser(string userName, string userPassword)
        {
            // Notify user
        }

        #endregion
    }
}
