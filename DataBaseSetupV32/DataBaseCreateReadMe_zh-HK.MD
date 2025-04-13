

★★★★★前置要求: 必須先在資料庫伺服器建立一個空白的資料庫和登錄資料庫的帳戶。

使用說明與要求:

1:要求用戶併發連接,注意設置連接串: The connection does not support MultipleActiveResultSets

   MS SQL 2016  DATABASE 屬性> Restrict Access = MULTI_USER
   同時連接串要加上多用戶
     "ConnectionStrings": {
    "DefaultConnection": "Data Source=(local)\\DATAGUARD;Initial Catalog=DataGuardXCoreM1;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true"
  },

2\Language.Json 設置種子數據語言
Language.json 檔來自 LangMXcore 程式下的 DATA/Language.json 如果有改動需要先啟動 LangMXcore.exe 按鈕 [TS-JSON],獲取最新版本,使用JSON版的比較靈活,內置系統版本更新@2022-1-18

3: 命令方式 $ DataBaseCoreCoreV3 "20211210" , "IN60006"  第一個參數是總公司ID,要求少於等於8位的數字。

4：注意黃色提示的文字，是要求選擇項的，一般 按鍵是 [SPACE] [ENTER] [ESC] [F3] 等等。 [ENTER] 是默認操作

5:appsettings.json 配置預設系統用戶賬戶,運行完成後,必須變更,否則導致下一次創建總公司的時候重複,導致無法創建賬戶。

發佈的最終檔:

../bin/Release
