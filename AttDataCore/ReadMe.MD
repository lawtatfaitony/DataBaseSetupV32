# Att DataCore.csproj 項目說明

**Encryption.dll 不適用 當前App** @2025-6-2

# 用於 DataBaseSetupV3 數據庫遷移

DataBase Setup V3 .csproj專案遷移需要專案 Att DataCore.csproj 引用

## Scaffold-dbcontext 指令使用說明

Microsoft.EntityFrameworkCore.Tools  v3.12  
Microsoft.EntityFrameworkCore.SqlServer v3.12
Microsoft.EntityFrameworkCore.Design v3.12
Microsoft.EntityFrameworkCore.Abstractions v3.12
Microsoft.EntityFrameworkCore v3.12

## AttDataCoreGenerator.csproj 

## 用於Scaffold生成資料庫程式碼項目

============================================================

2025-3-11 

為數據庫項目 [AttDataCore] 提供 生成 DbFirst 
Provided for database project [At&t Data Core] Generate Db First


命名空間: namespace AttendanceBussiness.DbFirst


第一步:

添加上命名空間:  AttendanceBussiness.DbFirst 後變成 :
参数 -namespace AttendanceBussiness.DbFirst

```
Scaffold-DbContext "Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir DbFirst -Context DataBaseContext -namespace AttendanceBussiness.DbFirst -UseDatabaseNames
```



## 詳細解釋上文
```
Scaffold-DbContext "Data Source=Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer `
-Force 
-OutputDir DbFirst 
-Context DataBaseContext 
-namespace AttendanceBussiness.DbFirst
-UseDatabaseNames  // # 关键参数：直接使用数据库表名，不修改为单复数形式
```

**第二步:**

```
Enable-Migrations
add-migration InitializeDatabase -c DataBaseContext
Add-Migration InitializeDatabase -Context DataBaseContext
```

第三步：

```
產生成功後，複製DbFirst 和 Migration 檔案夾到目標項目
```



## 删除现有迁移

```
Remove-Item -Path Migrations -Recurse -Force
改為：
Remove-Item -Path D:\APP\DGX_NET6\DGX_NET6\SourceCode\AttDataCore\Migrations -Recurse -Force
```



## 创建新迁移

```
Add-Migration InitialCreate -Context DataBaseContext
```

**數據類型的變化**

**生成後數據庫 中 bool 和 float 需要手動修改**

```
表 LeaveTypeDay  double 改回 float
public float MaxLeaveDaySpan { get; set; }
public float MaxLeaveNatureWorkDay { get; set; }
表 Device 中 bool? 改回 bool
public bool IsReverseHex { get; set; }  
```



## 应用迁移 這個語句導致數據庫被改變，危險，請小心使用
Update-DatabaseXXXXXXXX -Context DataBaseContext

 

#### 重點數據表命名規範 要注意：

 無法改動的 Language 涉及外面的軟件相連 

```
modelBuilder.Entity<Language>(entity =>
{
	。。。。
    //注意必須限制和定義資料表字段
    entity.Property(e => e.EnUs).HasColumnName("en_US").UseCollation("Chinese_Taiwan_Stroke_CI_AS");
    entity.Property(e => e.ZhCn).HasColumnName("zh_CN").UseCollation("Chinese_Taiwan_Stroke_CI_AS");
    entity.Property(e => e.ZhHk).HasColumnName("zh_HK").UseCollation("Chinese_Taiwan_Stroke_CI_AS");
});
```

需要改動 DrorCr




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

## 创建数据迁移：

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


//2022年4月29日
PM> Scaffold-DbContext "Data Source=(local)\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir DbFirst -Context DataBaseContext
Build started...
Build succeeded.
The column 'dbo.Shift.IsAutoCalcMissing' would normally be mapped to a non-nullable bool property, but it has a default constraint. Such a column is mapped to a nullable bool property to allow a difference between setting the property to false and invoking the default constraint. See https://go.microsoft.com/fwlink/?linkid=851278 for details.



## 清空數據庫

```
USE [DataGuardXcoreCreate];

EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'    
EXEC sp_MSForEachTable 'DELETE FROM ?' 							 
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL' 	 



DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP TABLE ' + QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) + ';' 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA <> 'sys';

EXEC sp_executesql @sql;
```



## 默認的SP備份

**創建  Store Procedure  [dbo].[SP_BACKUPDB]**

```
默認備份路徑
SET @strBackup = 'C:\DataBaseBAK\DataGuardXcore_' + @str + '.bak'  // DataGuardXcore_yyyyMMddHHmmss.bak
```

