

2025-3-11

為數據庫項目 [AttDataCore] 提供 生成 DbFirst 
Provided for database project [At&t Data Core] Generate Db First


命名空間: namespace AttendanceBussiness.DbFirst
 

第一步:


添加上命名空間:  AttendanceBussiness.DbFirst 後變成 :
参数 -namespace AttendanceBussiness.DbFirst
Scaffold-DbContext "Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir DbFirst -Context DataBaseContext -namespace AttendanceBussiness.DbFirst
# 詳細解釋
Scaffold-DbContext "Data Source=Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer `
-Force 
-OutputDir DbFirst 
-Context DataBaseContext 
-namespace AttendanceBussiness.DbFirst
-UseDatabaseNames  // # 关键参数：直接使用数据库表名，不修改为单复数形式

第二步:
Enable-Migrations
add-migration InitializeDatabase -c DataBaseContext
Add-Migration InitializeDatabase -Context DataBaseContext
# 删除现有迁移
Remove-Item -Path Migrations -Recurse -Force

# 创建新迁移
Add-Migration InitialCreate -Context DataBaseContext

# 应用迁移 這個語句導致數據庫被改變，危險，請小心使用
Update-Database -Context DataBaseContext


执行完毕后的提示：
To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
The column 'dbo.Department.IsActive' would normally be mapped to a non-nullable bool property, but it has a default constraint. Such a column is mapped to a nullable bool property to allow a difference between setting the property to false and invoking the default constraint. See https://go.microsoft.com/fwlink/?linkid=851278 for details.
The column 'dbo.Device.IsReverseHex' would normally be mapped to a non-nullable bool property, but it has a default constraint. Such a column is mapped to a nullable bool property to allow a difference between setting the property to false and invoking the default constraint. See https://go.microsoft.com/fwlink/?linkid=851278 for details.
The column 'dbo.LeaveTypeDay.IsForTotal' would normally be mapped to a non-nullable bool property, but it has a default constraint. Such a column is mapped to a nullable bool property to allow a difference between setting the property to false and invoking the default constraint. See https://go.microsoft.com/fwlink/?linkid=851278 for details.

為了保護連接字串中潛在的敏感訊息，您應該將其移出原始程式碼。您可以使用 Name= 語法從配置中讀取連接字串，以避免建立連接字串 - 請參閱https://go.microsoft.com/fwlink/?linkid=2131148。有關儲存連接字串的更多指導，請參閱http://go.microsoft.com/fwlink/?LinkId=723263。
列「dbo.Department.IsActive」通常會對應到非空的布林屬性，但它具有預設約束。這樣的列被對應到可空的 bool 屬性，以允許將屬性設為 false 和呼叫預設約束之間的差異。有關詳細信息，請參閱https://go.microsoft.com/fwlink/?linkid=851278。
列「dbo.Device.IsReverseHex」通常會對應到非空的布林屬性，但它具有預設約束。這樣的列被對應到可空的 bool 屬性，以允許將屬性設為 false 和呼叫預設約束之間的差異。有關詳細信息，請參閱https://go.microsoft.com/fwlink/?linkid=851278。
列「dbo.LeaveTypeDay.IsForTotal」通常會對應到非空的布林屬性，但它具有預設約束。這樣的列被對應到可空的 bool 屬性，以允許將屬性設為 false 和呼叫預設約束之間的差異。有關詳細信息，請參閱https://go.microsoft.com/fwlink/?linkid=851278。