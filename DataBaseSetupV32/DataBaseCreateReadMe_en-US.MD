

★★★★★ Prerequisites: You must first create a blank database on the database server and an account to log in to the database.

Instructions and requirements for use:

1: Require users to connect concurrently, pay attention to setting the connection string: The connection does not support MultipleActiveResultSets

   MS SQL 2016 DATABASE Properties > Restrict Access = MULTI_USER
   Simultaneous connection string to add multiple users
     "ConnectionStrings": {
    "DefaultConnection": "Data Source=(local)\\DATAGUARD;Initial Catalog=DataGuardXCoreM1;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true"
  },

2\Language.Json Set the seed data language
The Language.json file comes from DATA/Language.json under the LangMXcore program. If there is any change, you need to start the LangMXcore.exe button [TS-JSON] to get the latest version. It is more flexible to use the JSON version, and the built-in system version is updated @2022-1- 18

3: Command method $ DataBaseCoreCoreV3 "20211210" , "IN60006" The first parameter is the head office ID, which is strongly required to be less than or equal to 8 digits.

4: Pay attention to the text of the yellow prompt, which requires selection. Generally, the keys are [SPACE] [ENTER] [ESC] [F3] and so on.

5: The appsettings.json configures the default system user account. After the operation is completed, it must be changed. Otherwise, it will be repeated when the head office is created next time, and the account cannot be created.

Final file released:

../bin/Release
