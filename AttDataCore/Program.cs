using System;
using System.IO;
using AttendanceBussiness.DbFirst;
using Microsoft.Extensions.Configuration;
using AttendanceBussiness;
namespace AttDataCore
{
    class Program
    {
        static void Main(string[] args)
        { 
           
            DataBaseContext dbContext = new DataBaseContext();
            if (dbContext.Database.CanConnect())
            {
                Console.WriteLine("Database.CanConnect() = {0}", dbContext.Database.CanConnect());
                Console.ReadLine();
                Console.WriteLine("Press any key to close");
            }

            Console.WriteLine("Hello World!");
            string connetionStrings = ReadFromAppSettings().Get<ConnectionConfig>().ConnectionString;
            Console.WriteLine(connetionStrings);


            //配置连接串和数据库移植
            //dotnet ef migrations add InitialCreate
            //Build started...
            //Build succeeded.
            //Done.To undo this action, use 'ef migrations remove'

            //通过  'ef migrations remove' 移除数据迁移

            //dotnet ef database update

            //数据迁移 OK 测试验收通过版本！！！！
            //代码如下：
            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var db = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
            //    db.Database.Migrate();
            //}

            //host.Run();

        }
        public static IConfiguration ReadFromAppSettings()
        {
            string appsettingFile = $"appsettings.{Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT")}.json";
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile(appsettingFile, optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }

    public class ConnectionConfig
    {
        private string _Server;
        public string Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
            }
        }
        private string _DataBase;
        public string DataBase
        {
            get
            {
                return _DataBase;
            }
            set
            {
                _DataBase = value;
            }
        }
        private bool _IsTrustMode;
        public bool IsTrustMode
        {
            get
            {
                return _IsTrustMode;
            }
            set
            {
                _IsTrustMode = value;
            }
        }

        private string _UserId;
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private string _ConnectiongString;
        public virtual string ConnectionString
        {
            get
            {
                ////---------------------------------------------------------------------------------------------------
                if (_IsTrustMode)
                {
                    _ConnectiongString = string.Format("Server = {0}; Database = {1}; Trusted_Connection = True;Integrated Security=SSPI", Server, DataBase);
                }
                else
                {
                    _ConnectiongString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};TrustServerCertificate=True;ApplicationIntent=ReadWrite;", Server, DataBase, UserId, Password);
                }
                return _ConnectiongString;
            }
        }
    }
}
