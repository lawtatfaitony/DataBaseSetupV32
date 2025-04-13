using DataBaseSetupV3.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace DataBaseSetupV3
{
    public static class SysModuleInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();

        public static void SysModuleInitializeSeedData()
        {
            #region  Initialize seed data  SysModule
            string MainComId = SystemData.CreateMainComId();

            Site site = SiteInitialize.GetDetauleSite();

            //SysModuleId 必须硬性约定为: 品牌upcase + 型号 例如: HIK-DS-KIT804MF   
            var sysModules = new List<SysModule>
            {
                 new SysModule{

                     KeyId = $"SM{MainComId}{context.SysModule.Max(a => a.KeyId) + 1}",
                     SysModuleId ="LINUX_BOX" ,
                     SysModuleName ="LINUX_BOX",
                     Config= string.Empty,
                     FuncDesc = string.Empty,
                     SysModuleType = 0,
                     StartDate = DateTime.Now.AddYears(-3),
                     EndDate = DateTime.Now.AddYears(10),
                     GeneralStatus = 1,
                     MainComId = MainComId
                 },
                 new SysModule{

                     KeyId = $"SM{MainComId}{context.SysModule.Max(a => a.KeyId) + 2}",
                     SysModuleId ="ANDROID_NFC" ,
                     SysModuleName ="ANDROID_NFC",
                     Config ="",
                     FuncDesc = string.Empty,
                     StartDate = DateTime.Now.AddYears(-3),
                     EndDate = DateTime.Now.AddYears(10),
                     GeneralStatus = 1,
                     MainComId = MainComId
                 },
                 new SysModule{
                     KeyId = $"SM{MainComId}{context.SysModule.Max(a => a.KeyId) + 3}",
                     SysModuleId ="HIK-DS-KIT804MF" ,
                     SysModuleName ="HIK指紋刷卡一體機",
                     Config ="",
                     FuncDesc = string.Empty,
                     SysModuleType = 0,
                     StartDate = DateTime.Now.AddYears(-3),
                     EndDate = DateTime.Now.AddYears(10),
                     GeneralStatus = 1,
                     MainComId = MainComId
                 },
                 new SysModule
                 {
                    KeyId = $"SM{MainComId}{context.SysModule.Max(a => a.KeyId) + 4}",
                    SysModuleId="HIK-DS-KIT341BMW" ,
                    SysModuleName = "HIK人臉拍卡考勤機",
                    Config= string.Empty,
                    FuncDesc = string.Empty,
                    SysModuleType = 0,
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now.AddYears(10),
                    GeneralStatus = 1,
                    MainComId = MainComId
                 }
            };
            sysModules.ForEach(a =>
            {
                if (context.SysModule.Find(a.SysModuleId) == null)
                {
                    context.SysModule.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2}", a.SysModuleId, a.SysModuleName,a.MainComId));
                }
                else
                {
                    Console.WriteLine(string.Format("Exists : {0} {1} {2}",a.SysModuleId, a.SysModuleName,  a.MainComId));
                }
                Thread.Sleep(150);
            });
            context.SaveChanges();
            #endregion
        }
    }
}