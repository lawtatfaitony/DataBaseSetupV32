using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading; 
using Caching;
using DataBaseSetupV3;
using DataBaseSetupV3.Context;
using DataBaseSetupV3.Data;
using DataBaseSetupV3.Model;
using Encryption;
using LanguageResource;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataBaseSetupV3
{
    class Program
    {
        public static CancellationToken cancellationToken { get; set; }
        public static readonly FIFOCache<string, byte[]> cache = RunTimeCache.FIFOCache();
        static void Main(string[] args)
        {
            Console.Title = "數據庫服務初始化部署 Database Service Initial Deployment ";
            Console.WriteLine("\n[--------------------{0}-------------------------------]\n", Console.Title);

            DateTime dt = DateTime.Now.AddHours(3);
            DateTimeOffset thisOffsetTime = new DateTimeOffset(dt);

            SystemData.SetParmsCache(args, thisOffsetTime);

            #region TEST
            var UninTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var DateTimeUnix = DateTimeOffset.FromUnixTimeMilliseconds(UninTimeStamp);
            //计算两个时间间隔
            TimeSpan timeSpan = new TimeSpan(DateTimeOffset.UtcNow.Ticks - DateTimeUnix.Ticks);
            Console.WriteLine("{0}", timeSpan);
            SystemData.CheckParmsCache();
            #endregion

            DataBaseContext context1 = new DataBaseContext();
            Console.WriteLine("\n[TRY TO CONNECT DATABASE..............................]\n");
            Console.WriteLine("\n[DATABASE CONNECTION STRING : {0}]\n", context1.Database.GetDbConnection().ConnectionString);
            
            if (context1.Database.CanConnect())
            {
                Console.WriteLine("\n[DATABASE CONNECT SUCCESS !!!..............................]\n\n");
                Console.WriteLine("\n[DATABASE :{0}] [ProviderName:{1}] \n\n", context1.Database.GetDbConnection().Database,context1.Database.ProviderName);
            }
            else
            {
                Console.WriteLine("\n[FATAL] [DATABASE CONNECT FAIL !!!..............................]\n");
                Console.ReadLine();
            }

            //To determine the reference last revised date time
            InistializeData1.GtLanguageJsonRevisedReference();

            Console.WriteLine("\n[PLEASE PRESS [ENTER] TO CONTINUE\n");
            ConsoleKeyInfo consoleKeyInfoConTinue = new ConsoleKeyInfo();
            while (consoleKeyInfoConTinue.Key != ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[PLEASE PRESS [ENTER] TO CONTINUE\n");
                Console.ResetColor();
                consoleKeyInfoConTinue = Console.ReadKey();
                if (consoleKeyInfoConTinue.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            cancellationToken = new CancellationToken(); 
            Console.OutputEncoding = System.Text.Encoding.Unicode;
             
            Console.WriteLine("Hello World!");
            string languageCode = LangUtilities.LanguageCode;
             
           
            String source = ChineseStringUtility.ToAutoTraditional("IGORE THIS LIINE:恭喜發財 字体顯示 中国香港澳门台湾新加坡 [Testing For Simplified and Traditional Transform]\n");
            Console.WriteLine("\n[CN<=>HK] \n {0}", source);
             
            Console.Title = "DATABASE SEED BATCH DATA STARTING ";

            #region BEGIN MIGRATE

            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<DataBaseContext>();

            //check SQL Connection
            bool camConnect = false;
            camConnect = context.Database.CanConnect();
            bool sureCreated = context.Database.EnsureCreated();
            if (camConnect)
            {
                Console.WriteLine("\nSQL Server Is Connecting......");
                string _CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");// Configurations.ReadFromAppSettings.AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
                Console.WriteLine("\n[CAN CONNECT] [OK] CONNNECTION STRING: \n{0}\n", _CONNECTION_STRING); //test
            }else
            {
                Console.WriteLine("\n[DATABASE EXCEPTION] [CONNECT FAILED] [CHECK CONNECTION_STRING]");
                //goto Q;
            }
                
            Stopwatch sw = new Stopwatch();
            sw.Start();

            #region [MIGRATE]

            if (camConnect)
            {  
                if (!sureCreated)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[EXECUTING MIGRATE]......");
                    Console.ResetColor();
                    
                    try
                    {
                        var migrator = context.Database.GetService<IMigrator>();
                        migrator.MigrateAsync("targetMigration", cancellationToken);

                        Console.WriteLine("\n[CANCEL CREATE DATABASE? PLEASE PRESS [ESC]==========================================]\n");
                        ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo();
                        while (consoleKeyInfo.Key != ConsoleKey.Escape)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n[CANCEL CREATE DATABASE? PLEASE PRESS [ESC]==========================================]\n");
                            Console.ResetColor();
                            consoleKeyInfo = Console.ReadKey();
                            if (consoleKeyInfo.Key == ConsoleKey.Escape)
                            {
                                cancellationToken = new CancellationToken(true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n[EXCEPTION] [MIGRATION EXCEPTION]\n {0}", ex.Message);
                    }

                    if (context.Database.GetPendingMigrations().Any() == false)  //need to panding?
                    {
                        Console.WriteLine("\n[MIGRATE FINISHED]......");

                        //如果已經創建table後,先插入行業表以及緩存行業ID
                        //行業輸入與初始化行業種子數據------------------------------------------------------------------------- 
                        InistializeData1.SelectIndustryAndInsertIndustryJsonDataFirrst(languageCode);
                        //-----------------------------------------------------------------------------------------------------
                         
                    }

                    Console.WriteLine("\n[MIGRATE FINISHED]......");

                    //如果已經創建table後,先插入行業表以及緩存行業ID
                    //行業輸入與初始化行業種子數據------------------------------------------------------------------------- 
                    InistializeData1.SelectIndustryAndInsertIndustryJsonDataFirrst(languageCode);
                    //-----------------------------------------------------------------------------------------------------
                }
                else //已經創建數據庫
                {
                    Console.WriteLine("\n[SURE CREATED (DATABASE)] [MIGRATION HAS DONE BEFORE]");


                    //如果已經創建table後,先插入行業表以及緩存行業ID
                    //行業輸入與初始化行業種子數據------------------------------------------------------------------------- 
                    InistializeData1.SelectIndustryAndInsertIndustryJsonDataFirrst(languageCode);
                    //-----------------------------------------------------------------------------------------------------
                }
            }
        // Thread.Sleep(3000);
        #endregion
            bool v = true;
#if RELEASE
            v = EncryptionRSA.VerifyCurrentMachine();
            Console.WriteLine("ERSA {0} (AppAuth.key)", v);
            if (v == false)
            {
                Console.WriteLine("v {0}", v);
                return;
            }
#endif
            if (v)
            {
                Console.WriteLine("CHECK ERSA = {0}", v);

                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                     
                try
                {
                    //InistializeData1=========================================================================================================
                    InistializeData1.RunTaskSeedData(languageCode);
                    //=========================================================================================================================

                    // app run entry
                    //Task appResult = serviceProvider.GetService<App>().Run();  //await serviceProvider.GetService<App>().Run(args);
                   serviceProvider.GetService<App>().Run(languageCode);
                     
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex, "[APP RUN EXCEPTION ERROR OCCURED ]");
                }
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERSA UNAUTHORIZED {0}", v);
                Console.ResetColor();
            }
             
            //end
            string time = sw.Elapsed + "(" + sw.Elapsed.Seconds + "s" + sw.Elapsed.Milliseconds + "ms)";
            Console.WriteLine(">>> Elapsed Time = {0}", sw.Elapsed);
            sw.Stop();

        Q:
            Console.WriteLine(">>> [PROGRAM END TO RUN]");
            #endregion END   

            #region RELATE USER TO COMPANY  #####这部分不要 出问题 2022年5月15日 需要测试
            Console.WriteLine("[WAITING......]");
            Thread.Sleep(12000);
            //CHECK CACHE
            SystemData.CheckParmsCache();

            InistializeData1.MainComId = SystemData.CreateMainComId();
            InistializeData1.IndustryId = SystemData.GetIndustryId();
            string relateTips = $"\n [USER RELATE TO COMPANY (MainComId = {InistializeData1.MainComId})] [OTHERWISE,NEED TO REGIST A NEW COMPANY BY WEB] \nPRESS [ENTER] TO RELATE.......[ESC] TO EXIST!!!";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(relateTips); 
            ConsoleKeyInfo consoleKeyInfoForRegister = new ConsoleKeyInfo();
            consoleKeyInfoForRegister = Console.ReadKey();
            while (consoleKeyInfoForRegister.Key != ConsoleKey.Escape)
            {  
                if (consoleKeyInfoConTinue.Key == ConsoleKey.Enter)
                { 
                    //UPDATEMAINCOMID 更新MainComId 和 IndustryId 
                    InistializeData1.UpdateUsersMainComId(InistializeData1.MainComId, InistializeData1.IndustryId);
                    break;
                }  
                Console.WriteLine(relateTips);
                consoleKeyInfoForRegister = Console.ReadKey();
            }
            Console.ResetColor();

            //創建備份存儲過程 
            //InistializeData1.CreateStoreProcedure(); //改用手動 執行腳本

            //FINISHED!!!

            Thread.Sleep(2000);

            string existConsoleTips = "\n\t[Congratulations!!! SUCCESSFULLY TO COMPLETE] [F3]\n\n\t";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(existConsoleTips);  
            ConsoleKeyInfo consoleKeyFINISHED = new ConsoleKeyInfo();
            consoleKeyFINISHED = Console.ReadKey();
            while (consoleKeyFINISHED.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(existConsoleTips);
                consoleKeyFINISHED = Console.ReadKey();
                if (consoleKeyFINISHED.Key == ConsoleKey.F3)
                {
                    break;
                }
            }
             
            #endregion
        }
        public static IConfiguration ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            // 配置日志
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });
            // 创建 appsettings
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //IdentityCore START  
            services.AddDefaultIdentity<IdentityUser>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 0;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredUniqueChars = 0;
                    }
                )
                .AddRoles<IdentityRole>() //2022-1-18
                .AddUserManager<UserManager<IdentityUser>>()
                .AddSignInManager<SignInManager<IdentityUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //IdentityCore END

            services.Configure<List<SystemUser>>(configuration.GetSection("systemUserList"));
            services.AddSingleton<IList<SystemUser>, List<SystemUser>>();
            services.AddTransient<App>();
        }
         
    }
}
