﻿Microsoft.EntityFrameworkCore.Tools  v3.12
Microsoft.EntityFrameworkCore.SqlServer v3.12
Microsoft.EntityFrameworkCore.Design v3.12
Microsoft.EntityFrameworkCore.Abstractions v3.12
Microsoft.EntityFrameworkCore v3.12

//OK 2021-4-14
第一步：注意 连接串问题，多数情况都是这个问题。添加上述组件后，运行一下命令，首次则要去掉 -force 。并且把AttDataCore.proj设为启动项目

先把  DataBaseCreateCoreV3\Context\DataBaseContext.cs 的
protected override void OnConfiguring 去掉注释,
把 context下的DataguardXcontext.cs注释掉
 
然後執行第一步: 腳手架創建 MODEL 
  
Scaffold-DbContext "Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Model -Context DataBaseContext
 
 # 詳細解釋
Scaffold-DbContext "Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer `
-Force 
-OutputDir DbFirst 
-Context DataBaseContext 
-namespace AttendanceBussiness.DbFirst
-UseDatabaseNames  // # 关键参数：直接使用数据库表名，不修改为单复数形式

第二步：启动迁移，添加迁移，更新迁移。目标把数据库架构同步到代码，一边创建脚本和数据库一致。

PM> Enable-Migrations 
PM> Add-Migration 不行 要指定具体上下文 : 这个可以:add-migration InitializeDatabase -c DataBaseSetupV3.Model.DataBaseContext
PM> Update-Database 不行 用這個 上行結構到數據庫: Update-Database  -c DataBaseContext 

 add-migration InitializeDatabase -c DataBaseContext

 ==========================================================================================================
 這個語句導致數據庫被改變，危險，請小心使用
 update-database -c DataBaseContext (这个不用,是反过来更新数据库结构)


获取表的存储大小

exec sp_spaceused  attendancelog 
exec sp_spaceused '表名' --取得表占用空間 
exec sp_spaceused ''--數據庫所有空間 














Scaffold-DbContext "Data Source=(local)\DATAGUARD;Initial Catalog=DataGuardX;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models -Context DatabaseContext -ContextNamespace AttendanceBussiness.DbFirst

这句对的。

Scaffold-DbContext "Data Source=(local)\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models -Context DatabaseContext

OK as follows (2021-04-14):
Scaffold-DbContext "Data Source=(local)\\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir DbFirst -Context DataBaseContext
OK as follows (2021年2月28日):

创建数据迁移：

dotnet ef migrations add InitialCreate
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

通过  'ef migrations remove' 移除数据迁移

//2021年3月1日

//数据库更新命令
Update-Database

Update-Database -ConfigurationTypeName "XXX"
Update-Database -ConfigurationTypeName  "数据库名称"

//BEGIN =============================================================
PM> Enable-Migrations
Enable-Migrations is obsolete. Use Add-Migration to start using Migrations.
PM> Add-Migration
位于命令管道位置 1 的 cmdlet Add-Migration
请为以下参数提供值:
Name: Initialize
Build started...
Build succeeded.
More than one DbContext was found. Specify which one to use. Use the '-Context' parameter for PowerShell commands and the '--context' parameter for dotnet commands.
PM> Add-Migration -Context AttendanceBussiness.DbFirst.DataBaseContext
位于命令管道位置 1 的 cmdlet Add-Migration
请为以下参数提供值:
Name: Initialize
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM>
//END ===============================================================


数据迁移 OK 测试验收通过版本！！！！ 


注意：
JSONDATA 文件夹下的json 如果存在则执行这里的数据同步到数据库，否则执行程序代码的。
可以暂时把json文件改名，避开执行jsaon。

数据库实例名称Instance Name：DATAGUARD
必须创建null的数据库 DataGuard123 
连接串账户：admin
密码：admin123

创建的系统登录账户保存在应用程序目录下的 Account_xxxxx.txt文件。

====================================================================================================================
Nutget控制台下输入命令：
PM> dotnet ef migrations add InitialCreate -c DatabaseContext
出现的问题
No project was found. Change the current working directory or use the --project option.
解决：
dotnet ef migrations script --verbose -i --project "D:\STARXXX\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate.csproj"  【这句test ok】

 dotnet --project "D:\STARON\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate.csproj"  ef migrations add InitialMigration

 解决II:
 在cmd命令下，cd 转到proj所在文件夹下，输入命令：
 dotnet ef migrations add InitialCreate
前提要保证 项目Build 生成成功。


 //========================================================================================================
 连接串是独立程序集的写法：

 解决：如果DBContext和启动程序不在一个程序集，需要指定要迁移的程序集。代码中添加要迁移的程序集名称：

 在文件 【DatabaseContext.cs】 把对应的连接串改为如下：
 options.UseSqlServer(connection, b => b.MigrationsAssembly("Do.TmsApi"))

 来源：https://www.cnblogs.com/gaozejie/p/12422112.html

 //=======================================================================================================
 CMD Console 控制台命令实现数据库移植：

 F:\STAR\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate>dotnet ef migrations add InitialDatabase
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'
 