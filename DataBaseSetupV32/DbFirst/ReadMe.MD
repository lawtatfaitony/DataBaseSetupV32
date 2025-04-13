

2025-3-11

為數據庫項目 [AttDataCore] 提供 生成 DbFirst 
Provided for database project [At&t Data Core] Generate Db First


命名空間: namespace AttendanceBussiness.DbFirst
 

第一步:


添加上命名空間:  AttendanceBussiness.DbFirst 後變成 :
Scaffold-DbContext "Data Source=TOPSERVER\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir DbFirst -Context DataBaseContext -namespace AttendanceBussiness.DbFirst

第二步:
add-migration InitializeDatabase -c DataBaseContext