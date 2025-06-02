using DataBaseSetupV3.Data;
using AttendanceBussiness.DbFirst   ;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace DataBaseSetupV3
{
    public partial class InistializeData1
    {
        public static string MainComId { get; set; }
        public static string IndustryId { get; set; }

        private static DataBaseContext databaseContext = Configurations.GetDataBaseContext();

        /// <summary>
        /// 獲取 Language.json 的生成時間以確定最新修訂時間
        /// </summary>
        public static void GtLanguageJsonRevisedReference()
        {
            string baseDirectoryPath = System.Environment.CurrentDirectory;
            string JsonDataPath = Path.Combine(baseDirectoryPath, "JsonData");
            string LangJsonDataFile = Path.Combine(JsonDataPath, "Language.json");
            FileInfo languageJsonInfo = new FileInfo(LangJsonDataFile);

            string msg = $"Language Version : JsonData/Language.json @{languageJsonInfo.LastWriteTime} (To determine the reference last revised date time.)";

            Console.WriteLine(msg);

        }
        public static void RunTaskSeedLanguageJsonData()
        {
            string baseDirectoryPath = System.Environment.CurrentDirectory;
            string JsonDataPath = Path.Combine(baseDirectoryPath, "JsonData");
            string LangJsonDataFile = Path.Combine(JsonDataPath, "Language.json");
            //------------------------------------------------------------------ 
            if (File.Exists(LangJsonDataFile))
            {
                int keyNameIndex = 0;
                string LangJson = File.ReadAllText(LangJsonDataFile, Encoding.UTF8);
                List<LanguageJsonF> languages = JsonConvert.DeserializeObject<List<LanguageJsonF>>(LangJson);
                foreach (var item in languages)
                {
                    keyNameIndex++;
                    Language language = databaseContext.Language.Find(item.KeyName);

                    if (language == null)
                    {
                        Language languageF = new Language
                        {
                            KeyName = item.KeyName,
                            KeyType = item.KeyType,
                            ZhCn = item.ZhCn,
                            ZhHk = item.ZhHk,
                            EnUs = item.EnUs,
                            IndustryIdArr = item.IndustryIdArr,
                            MainComIdArr = item.MainComIdArr
                        };
                        databaseContext.Language.Add(languageF);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\n[Index:{6}] SUCCESS FROM JSON ADD NEW:{5} : {0} {1} {2} {3} Industry Arr={4}", item.KeyName, item.KeyType, item.ZhCn, item.ZhHk, item.EnUs, item.IndustryIdArr, result, keyNameIndex));
                    }
                    else
                    {
                        language.KeyType = item.KeyType;
                        language.ZhCn = item.ZhCn;
                        language.ZhHk = item.ZhHk;
                        language.EnUs = item.EnUs;
                        language.MainComIdArr = item.MainComIdArr;
                        language.IndustryIdArr = item.IndustryIdArr;
                        language.Remark = item.Remark;

                        databaseContext.Language.Update(language);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\n[Index:{6}] SUCCESS FROM JSON UPDATE:{5} : {0} {1} {2} {3} IndustryIdArr={4}", item.KeyName, item.KeyType, item.ZhCn, item.ZhHk, item.EnUs, item.IndustryIdArr, result, keyNameIndex));
                    }


#if DEBUG
                    int delay = 50; 
                    Thread.Sleep(delay);
#endif

                }
            }
            else
            {
                LangInitialize.LanguageSeedData();
            }

            Console.WriteLine("[{0:F}][LANGUAGE DATA SYNCHRONIZED FINISHED]",DateTime.Now); 
        }

        /// <summary>
        /// 獲得 AspNetPermissions.json 的數據
        /// </summary>
        /// <returns></returns>
        public static List<AspNetPermissions> GetAspNetPermissionsJson()
        {
            string baseDirectoryPath = System.Environment.CurrentDirectory;
            string JsonDataPath = Path.Combine(baseDirectoryPath, "JsonData");
            string AspNetPermissionsJsonFile = Path.Combine(JsonDataPath, "AspNetPermissions.json");
            FileInfo aspNetPermissionsJsonInfo = new FileInfo(AspNetPermissionsJsonFile);

            string msg = $"Language Version : JsonData/AspNetPermissions.json @{aspNetPermissionsJsonInfo.LastWriteTime} (To determine the reference last revised date time.)";

            Console.WriteLine(msg);

            string AspNetPermissionsJson = File.ReadAllText(AspNetPermissionsJsonFile, Encoding.UTF8);
            List<AspNetPermissions> aspNetPermissionsList = JsonConvert.DeserializeObject<List<AspNetPermissions>>(AspNetPermissionsJson);

            return aspNetPermissionsList;

        }
        /// <summary>
        /// 批量處理 AspNetPermissions.json 的數據
        /// </summary>
        public static void RunTaskSeedAspNetPermissionsJsonData()
        {  
            List<AspNetPermissions> aspNetPermissionsList = GetAspNetPermissionsJson();
            if (aspNetPermissionsList!=null)
            { 
                foreach (var item in aspNetPermissionsList)
                {

                    AspNetPermissions aspNetPermissions = databaseContext.AspNetPermissions.Find(item.Id);

                    if (aspNetPermissions == null)
                    { 
                        databaseContext.AspNetPermissions.Add(item);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\nAspNetPermissions ADD NEW SUCCESS FROM (AspNetPermissions.Json): [ID: {0}] : [{1}] [Name: {2}] [RoleClaims: {3}] [Result: {4}]", item.Id, item.Name, item.ControllerName, item.ActionName, item.RoleClaims, result));
                    }
                    else
                    { 
                        databaseContext.AspNetPermissions.Update(item);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\nAspNetPermissions UPDATE SUCCESS FROM (AspNetPermissions.Json): [ID: {0}] : [{1}] [Name: {2}] [RoleClaims: {3}] [Result: {4}]", item.Id, item.Name, item.ControllerName, item.ActionName, item.RoleClaims, result));
                    }
                    int delay = 500;
#if DEBUG
                    delay = 100; 
#endif 
                    Thread.Sleep(delay);
                }

                Console.WriteLine("[{0:F}][AspNetPermissions DATA SYNCHRONIZED FINISHED]", DateTime.Now);
            }
        }

        /// <summary>
        /// 輸入行業ID 與 初始化行業種子數據
        /// 手動輸入行業ID，這個功能目前是無法進入這個流程節點，因為前面如果沒有行業ID，設置默認緩存是 : IN60006
        /// </summary>
        /// <param name="languageCode"></param>
        public static void SelectIndustryAndInsertIndustryJsonDataFirrst(string languageCode)
        { 
            Console.WriteLine("\n[ Industry Seed Data (json file first)]");
            RunTaskSeedIndustryJsonData(languageCode);
             
            Console.WriteLine("\nPress input Industry No. as follows");
            Console.WriteLine("\n[INDUSTRY LIST)]===============================================\n");
            var context = Configurations.GetDataBaseContext();
            foreach (var item in context.Industry.ToList())
            {
                Console.WriteLine("{0} {1} {2}", item.IndustryId, item.IndustryName,item.EnIndustryName);
            }

            if (!string.IsNullOrEmpty(SystemData.GetIndustryId()))
            {
                IndustryId = SystemData.GetIndustryId(); 
            }
            else
            {
                IndustryId = string.Empty; 
            }

            if (string.IsNullOrEmpty(IndustryId))
            {
                bool IsCorrectIndustryId = false;
                while (!IsCorrectIndustryId)
                {
                    Industry industry = databaseContext.Industry.Find(IndustryId);
                    if (industry == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        IsCorrectIndustryId = false; //不正確的Industry ID
                        Console.WriteLine("\n==========================================================================\n");
                        Console.WriteLine("\nPress input Industry ID \n");
                        Console.WriteLine("\nPlease Press input Industry ID :\n");

                        IndustryId = Console.ReadLine();

                        Console.ResetColor();
                    }
                    else
                    {  
                        IndustryId = industry.IndustryId;
                        SystemData.SetIndustryIdCache(IndustryId);
                        IsCorrectIndustryId = true;
                    }
                }
            }
        }
        /// <summary>
        /// 行業種子數據批量插入
        /// </summary>
        /// <param name="languageCode"></param>
        public static void RunTaskSeedIndustryJsonData(string languageCode)
        {
            string baseDirectoryPath = System.Environment.CurrentDirectory;
            string JsonDataPath = Path.Combine(baseDirectoryPath, "JsonData");
            string filename = $"Industry.{languageCode}.json";
            string IndustryJsonDataFile = Path.Combine(JsonDataPath, filename);
            //------------------------------------------------------------------ 
            if (File.Exists(IndustryJsonDataFile))
            {
                string IndustryJson = File.ReadAllText(IndustryJsonDataFile, Encoding.UTF8);
                List<Industry> industries = JsonConvert.DeserializeObject<List<Industry>>(IndustryJson);
                foreach (var item in industries)
                { 
                    Industry industry = databaseContext.Industry.Find(item.IndustryId);

                    if (industry == null)
                    {
                        Industry industryNew = new Industry
                        {
                            IndustryId = item.IndustryId,
                            IndustryName = item.IndustryName,
                            EnIndustryName = item.EnIndustryName,
                            ParentsIndustryId = item.ParentsIndustryId
                        };
                        databaseContext.Industry.Add(industryNew);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\nSUCCESS FROM JSON ADD NEW:{4} : {0} {1} {2}  {3}", item.IndustryId, item.IndustryName, item.EnIndustryName, item.ParentsIndustryId, result));
                    }
                    else
                    {
                        industry.IndustryId = item.IndustryId;
                        industry.IndustryName = item.IndustryName;
                        industry.EnIndustryName = item.EnIndustryName;
                        industry.ParentsIndustryId = item.ParentsIndustryId;

                        databaseContext.Industry.Update(industry);
                        int result = databaseContext.SaveChanges();
                        Console.WriteLine(string.Format("\nSUCCESS FROM JSON ADD NEW:{4} : {0} {1} {2}  {3}", item.IndustryId, item.IndustryName, item.EnIndustryName, item.ParentsIndustryId, result));
                    }


#if DEBUG
                    int delay = 50;
                    Thread.Sleep(delay);
#endif

                }
            }
            else
            {
                IndustryInitialize.IndustryInitializeSeedData();
            }

            Console.WriteLine("\n[{0:F}][INDUSTRY DATA SYNCHRONIZED FINISHED] \n", DateTime.Now);
        }
        public static void RunTaskSeedData(string LanguageCode)
        {
            //如果已經創建table後,先插入行業表以及緩存行業ID
            //行業輸入與初始化行業種子數據------------------------------------------------------------------------- 
            InistializeData1.SelectIndustryAndInsertIndustryJsonDataFirrst(LanguageCode);
             

            //---------------- -------------------------- ----------------------
            Console.WriteLine("\n[ MainCom ]");
            MainComInitialize.MainComInitializeSeedData(LanguageCode,InistializeData1.IndustryId,out string mainComId);
            InistializeData1.MainComId = mainComId;
            //---------------- ------------------------ ------------------------ 

            //---------------- ------------------------ -----------------------
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ Multi-Language ] PRESS [ESC] TO SKIP ;Press [ENTER] TO CREATE [Multi-Language]..................\n");
            ConsoleKey keyOfMultiLanguage = Console.ReadKey().Key;
            Console.ResetColor();

            if (keyOfMultiLanguage == ConsoleKey.Enter)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ Use Built-in Language Dictionary Press [SPACE], otherwise [ENTER] execute Language.json Dictionary]");
                Console.ResetColor();

                ConsoleKey key = Console.ReadKey().Key;

                if (key != ConsoleKey.Enter)
                {
                    LangInitialize.LanguageSeedData();
                }
                else
                {
                    InistializeData1.RunTaskSeedLanguageJsonData();
                }
            }
            else
            {
                Console.WriteLine("\n[SKIP Multi-Language]\n");
            }
            
            //---------------- ------------------------ ------------------------ 

            //----------------- ------------------------ -----------------------
            Console.WriteLine("\n[ Department ]");
            DepartmentInitialize.DepartmentInitializeSeedData(IndustryId);
            //------------------ ------------------------ ----------------------
            Console.WriteLine("\n[ Contractor ]");
            ContractorInitialize.ContractorInitializeSeedData(IndustryId);
            //-------------------- --------------------- -----------------------
            Console.WriteLine("\n[ Site ]");
            SiteInitialize.SiteInitializeSeedData();
            //--------------------- --------------------- ---------------------- 
            Console.WriteLine("\n[ Job (Type of work ])");
            JobInitialize.JobInitializeSeedData();
            //------------------------------------------------------------------
            Console.WriteLine("\n[ Shift ]");
            ShiftInitialize.ShiftInitializeSeedData(); 
            //-----------------------------------------------------------------
            Console.WriteLine("\nSysModule Initialize:");
            SysModuleInitialize.SysModuleInitializeSeedData();
            //--------------------- --------------------- ---------------------
            Console.WriteLine("\n[ Postion Data Initialize ]");
            PostionInitialize.PostionInitializeSeedData(); 
            //--------------------- --------------------- ---------------------  
            Console.WriteLine("[ TaskSetting ]");
            TaskSettingInitialize.TaskSettingInitializeSeedData();
            //--------------------- --------------------- ---------------------
            Console.WriteLine("\n[ Device ]");
            DeviceInitialize.DeviceInitializeSeedData();
            //---------------- ------------------------ ------------------------ 

            Console.WriteLine("\n[ The TableIdentity ]");
            TableIdentityInitialize.TableIdentityInitializeSeedData();
            //------------------------------------------------------------------

            Console.WriteLine("\n[ Create Roles ]");
            UserRoleInitialize.RoleSystemCreated();
            //--------------------- --------------------- ---------------------

            Console.WriteLine("\n[ AspNetPermssions Synchronize ]");
            InistializeData1.RunTaskSeedAspNetPermissionsJsonData();
            //--------------------- --------------------- ---------------------

            Console.WriteLine("\n[ Holiday Data Import Synchronize ]");
            HolidayInitialize.HolidayKeyDataImport();
            //--------------------- --------------------- ---------------------
            
            Console.WriteLine("\n\n[ FINISHED ]");
            Console.WriteLine("");
        }

        public static bool TableExists(string schema, string tableName)
        {
            using (DataBaseContext databaseContext = new DataBaseContext())
            {
                var connection = databaseContext.Database.GetDbConnection();

                if (connection.State.Equals(ConnectionState.Closed))
                    connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
                                            WHERE TABLE_SCHEMA = @Schema
                                            AND TABLE_NAME = @TableName";

                    var schemaParam = command.CreateParameter();
                    schemaParam.ParameterName = "@Schema";
                    schemaParam.Value = schema;
                    command.Parameters.Add(schemaParam);

                    var tableNameParam = command.CreateParameter();
                    tableNameParam.ParameterName = "@TableName";
                    tableNameParam.Value = tableName;
                    command.Parameters.Add(tableNameParam);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public static void CreateStoreProcedure()
        {
            string SP_BACKUPDB_SQL = @"
                            /****** Object:  StoredProcedure [dbo].[SP_BACKUPDB]    Script Date: 15/9/2024 13:11:55 ******/
                            SET ANSI_NULLS ON
                            GO
                            SET QUOTED_IDENTIFIER ON
                            GO

                            ALTER PROCEDURE [dbo].[SP_BACKUPDB]
                            AS
                            DECLARE @strBackup nvarchar(200)
                            DECLARE @strBackupIshopX nvarchar(200)
                            --DECLARE @strToday nvarchar(8)
                            --DECLARE @strTime nvarchar(8)
                            --SELECT @strToday = CONVERT(CHAR(8), GETDATE(), 112)
                            --SELECT @strTime = LEFT(CONVERT(CHAR(8), GETDATE(), 108), 2) + SUBSTRING(CONVERT(CHAR(8), GETDATE(), 108), 4, 2) + RIGHT(CONVERT(CHAR(8), GETDATE(), 108), 2)

                            DECLARE @str varchar(200)
                            set @str = replace(replace(replace(CONVERT(varchar, getdate(), 120 ),'-',''),' ',''),':','')
  
                            SET @strBackup = 'C:\DataBaseBAK\DataGuardXcore_' + @str + '.bak'
 
                            BACKUP DATABASE DataGuardXcore
                            TO DISK= @strBackup
                            WITH FORMAT"
            ;
            var connection = databaseContext.Database.GetDbConnection();

            try
            {
                using var command = connection.CreateCommand();

                command.CommandText = SP_BACKUPDB_SQL;

                bool result = command.ExecuteScalar() != null;

                Console.WriteLine($"[SP_BACKUPDB_SQL] [RESULT={result}]");
            }
            catch
            {
                return;
            }
            
        }

        public static void UpdateUsersMainComId(string mainComId,string industryId)
        {
            try
            {
                DataBaseContext dataBaseContext = Configurations.GetDataBaseContext(); 
                var userlist = dataBaseContext.AspNetUsers;
                if (userlist.Count() > 0)
                {
                    try
                    { 
                        var newUserlist = dataBaseContext.AspNetUsers;
                        foreach (var item in newUserlist)
                        {
                            item.MainComId = mainComId;
                            item.IndustryId = industryId;
                            dataBaseContext.AspNetUsers.Update(item);
                            Console.WriteLine($"\n[{DateTime.Now:yyyy-MM-dd HH:mm:ss fff}][{item.UserName}]  [MainComId:{item.MainComId}] [IndustryId={industryId}] [USER ID:{item.Id}] [EMAIL:{item.Email}]");
                        }

                        bool resX = dataBaseContext.SaveChanges() > 0;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n[{DateTime.Now:yyyy-MM-dd HH:mm:ss fff}] [SAVE CHANGES] [{resX}] [MainComId:{mainComId}]  [IndustryId={industryId}] ");
                        Console.ResetColor();

                    }
                        catch (Exception ex)
                        {
                            string exLog = $"[UPDATE USERLIST][UPDATE MAINCOM ID]  [FAIL] [MainComId={mainComId}] [{ex}]";
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, exLog);
                            Console.ResetColor();
                            return;
                        }

                    }
                    else
                    {
                        string logline = $"[UPDATE USERLIST][UPDATE MAINCOM ID] [NO USER] [MainComId={mainComId}]\n";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, logline);
                        Console.ResetColor();
                    }
                    return;
                 
            }
            catch(Exception ex)
            {
                string exLog = $"[UPDATE USERLIST][UPDATE MAINCOM ID]  [FAIL] [MainComId={mainComId}] [{ex}]";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, exLog);
                Console.ResetColor(); 
                return ;
            }
        } 
    }
}
