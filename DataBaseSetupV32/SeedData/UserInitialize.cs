using DataBaseSetupV3.Model;
using DataBaseSetupV3.Data;
using DataBaseSetupV3.SeedData;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DataBaseContext = DataBaseSetupV3.Model.DataBaseContext;

namespace DataBaseSetupV3
{
    public class UserInitialize
    {
        private static UserManager<IdentityUser> _userManager; 
        public UserInitialize(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static List<Industry> Industries = new List<Industry>
        {
                new Industry{ IndustryId ="IN00001" , IndustryName = LangAuto.Auto("商用服務業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00002" , IndustryName = LangAuto.Auto("飲食業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00003" , IndustryName = LangAuto.Auto("通訊業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00005" , IndustryName = LangAuto.Auto("住戶服務業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00006" , IndustryName = LangAuto.Auto("教育服務業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00007" , IndustryName = LangAuto.Auto("金融業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00008" , IndustryName = LangAuto.Auto("政府部門"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00009" , IndustryName = LangAuto.Auto("醫院"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00010" , IndustryName = LangAuto.Auto("酒店業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00011" , IndustryName = LangAuto.Auto("進出口貿易"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00012" , IndustryName = LangAuto.Auto("保險業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00013" , IndustryName = LangAuto.Auto("電子製品業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00014" , IndustryName = LangAuto.Auto("金屬製品業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00015" , IndustryName = LangAuto.Auto("塑膠製品業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00016" , IndustryName = LangAuto.Auto("紡織業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00017" , IndustryName = LangAuto.Auto("服裝製品業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00018" , IndustryName = LangAuto.Auto("地產業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00019" , IndustryName = LangAuto.Auto("零售業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00020" , IndustryName = LangAuto.Auto("倉庫業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00021" , IndustryName = LangAuto.Auto("運輸業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00022" , IndustryName = LangAuto.Auto("福利機構"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00023" , IndustryName = LangAuto.Auto("批發業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00024" , IndustryName = LangAuto.Auto("其他社區及社會服務業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00025" , IndustryName = LangAuto.Auto("其他製造業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN00026" , IndustryName = LangAuto.Auto("其他個人服務業"), EnIndustryName ="",ParentsIndustryId=0 },
                new Industry{ IndustryId ="IN60006" , IndustryName = LangAuto.Auto("建造業"), EnIndustryName ="",ParentsIndustryId=0 }
        };
        public static void UserSystemAdminCreate(string IndustryId)
        {
            IndustryId = IndustryId.Trim();
            #region  Initialize  UserSystemAdminCreate 
            string Generate_UserId = SystemData.CreateSupervisorId();
            string MainConId = SystemData.CreateMainComId(); 
            string Email = string.Format("{0}@Admin.com", Generate_UserId);
            AspNetUsers aspNetUsers = new AspNetUsers {
                Id = Generate_UserId,
                UserName = $"U{Generate_UserId}",
                NormalizedUserName = $"U{Generate_UserId}",
                MainComId = MainConId,
                IndustryId = IndustryId,
                Email = Email,
                NormalizedEmail = Email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = SystemData.CreatePasswordHash(),
                SecurityStamp = SystemData.CreateSecurityStamp(),
                ConcurrencyStamp = SystemData.CreateConcurrencyStamp(),
                PhoneNumber = string.Empty,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false, 
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            
            if (context.AspNetUsers.Find(Generate_UserId) == null)
            {
                try
                { 
                    Console.WriteLine("Create a Supervisor(System admin user) :");
                     
                    string PasswordHash = SystemData.CreatePasswordHash();
                    string SecurityStamp = SystemData.CreateSecurityStamp();

                    string userId = EnsureUser(aspNetUsers.UserName, Email, PasswordHash, MainConId, IndustryId);

                    if (!string.IsNullOrEmpty(userId) )
                    {
                        string account = string.Format("SUCCESS PLEASE REMEMBER [WRITE DOWN][SAVE TO THE APPLICATION ROOT PATH AS FILE:ACCOUNT_{2}.TXT]: \n\n{0} Email = {1}, Password = admin888,  MainComId (CompanyId) = {2}", userId,Email, MainConId);
                        string AccountFile = Path.Combine(Directory.GetCurrentDirectory(), string.Format("Account_{0}.txt", userId)); 
                        File.AppendAllText(AccountFile, account, System.Text.Encoding.GetEncoding("UTF-8"));
                        Console.WriteLine(account);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(string.Format("Exception : {0}", e.Message));
                }
                       
                Thread.Sleep(20000);
            }
            else
            {
                Console.WriteLine(string.Format("EXISTS : {0}", aspNetUsers.Id));
            }
            #endregion
        }

        private static string EnsureUser(string userName, string email, string userPassword, string mainComId, string industryId)
        {
            var user = _userManager.FindByNameAsync(userName).GetAwaiter().GetResult();

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true
                };
                IdentityResult identityResult = _userManager.CreateAsync(user, userPassword).GetAwaiter().GetResult();
                if (identityResult.Succeeded)
                {
                    Console.WriteLine("\n[NEW SYSTEM USER] UserName = {0} Password = {1}", userName, userPassword);

                    string identityResultJson = JsonConvert.SerializeObject(identityResult);
                    string accountPathFile = Path.Combine(Directory.GetCurrentDirectory(), "AccountOfAdmin.JSON");
                    bool IsSave = SaveDataJson(identityResultJson, accountPathFile);
                    if (IsSave)
                        Console.WriteLine("\n[ACCOUNT OF ADMIN HAS SAVED]  [{0} [{1}]]", IsSave, accountPathFile);
                }
                else
                {
                    Console.WriteLine("\n[CREATE SYSTEM USER] UserName = {0} [FAIL]", userName);
                }
            }
            return user.Id;
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
    } 
}
