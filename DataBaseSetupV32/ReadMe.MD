

# DataGuardXcore Net 6.0.36 數據庫安裝程式

## 設置Appsettings.json

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  // 數據庫連接
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=192.168.0.9;Initial Catalog=DataGuardXCoreCREATE;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true;"
  },
  // 預設公司名稱
  "CompanyName": "長江新地有限公司1",
  // 預設系統超級用戶 與 管理用戶
  "systemUserList": [
    {
      "userName": "Supervisor",
      "email": "Supervisor@abc.com"
    },
    {
      "userName": "Admin",
      "email": "Admin@abc.com"
    }
  ],
  // 預設的默認安裝語言
  "languageConfig": {
    "Language": "zh-HK",
    "IsDefault": true
  },

  "AllowedHosts": "*"
}
```



## 注意

★★★★★前置要求: 必須先在數據庫服務器建立一个空白數據庫和登錄數據庫的賬戶。

**使用說明與要求:**

### 1、用戶並發連接 

要求用戶並發連接,注意設置連接串: The connection does not support MultipleActiveResultSets

   MS SQL 2016  DATABASE 屬性> Restrict Access = MULTI_USER
   同時連接串要加上多用戶

```
"ConnectionStrings": {
  "DefaultConnection": "Data Source=192.168.0.9;Initial Catalog=DataGuardXCoreCREATE;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true;"
},
```

### 2、 設置種子語言

Language.json 文件來自 LangMXcore 程序下的 DATA/Language.json 如果有改動需要先啟動 LangMXcore.exe 按鈕 [TS-JSON],獲取最新版本,使用JSON版的比較靈活,內置系統版本更新@2022-1-18

### 3、命令 

命令方式 $ DataBaseSetupV3 "20250610" , "IN60006"  第一個參數是總公司ID,強烈要求少於等於8位的數字。

### 4、注意黃色提示的文字

注意黃色提示的文字，是要求選擇項的，一般 按鍵是 [SPACE] [ENTER] [ESC] [F3] 等等。

### 5、appsettings.json 配置

appsettings.json 配置预设系统用户账户,运行完成后,必须变更,否则导致下一次创建总公司的时候重复,导致无法创建账户。

### 6、從政府獲得公眾假期

**政府數據： http://www.1823.gov.hk/common/ical/en.json**

```
 HttpResponseMessage response = await client.GetAsync("http://www.1823.gov.hk/common/ical/en.json");
```



## 發布的最終文件

../bin/Release

## 常见问题

若出现 NU1102 或 NU1202 错误
检查包名称是否拼写正确，例如：

❌ Microsoft.AspNetCore.Identity → 已废弃

✔️ Microsoft.AspNetCore.Identity.EntityFrameworkCore → 正确的Package Name