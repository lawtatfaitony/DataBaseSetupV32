using System;
using System.Collections.Generic; 
using System.Threading;
using AttendanceBussiness.DbFirst;
using Newtonsoft.Json;
namespace DataBaseSetupV3
{
    public static class DeviceInitialize
    {
        public static void DeviceInitializeSeedData()
        {
            var databaseContext = Configurations.GetDataBaseContext();
            
            #region  Initialize seed data TaskSettingId,CalcPeriodType,CalcPeriodSpan,TaskRuningStartTime,TaskRuningEndTime,TimesOfTaskRunning,TaskStartDate,TaskRemarks
            string MainComId = SystemData.CreateMainComId();
            ACCUIDconfig aCCUIDconfig = new ACCUIDconfig();
            var devices = new List<Device>
            {
                    new Device{
                        DeviceId ="NFCTAPCARD1" ,
                        SysModuleId="ANDROID_NFC",
                        DeviceName ="ANDROID NFC TAP CARD",
                        DeviceEntryMode = 0,
                        DeviceSerialNo = "SerialNo INPUT HERE",
                        OperatedUser = "SYSTEM",
                        UpdateDateTime = DateTime.Now,
                        Status = 1, //1 = Active
                        Config = JsonConvert.SerializeObject(aCCUIDconfig),
                        MainComId = MainComId
                    },
            };
            devices.ForEach(a =>
            {
                if (databaseContext.Device.Find(a.DeviceId) == null)
                {
                    databaseContext.Device.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.DeviceId, a.DeviceName, a.DeviceEntryMode,  a.MainComId));
                }
                else
                {
                    Console.WriteLine(string.Format("Exists : {0} {1} {2} {3}", a.DeviceId, a.DeviceName, a.DeviceEntryMode, a.MainComId));
                }
                Thread.Sleep(100);
            });
            databaseContext.SaveChanges();
            #endregion
            
        }
    }

    public class ACCUIDconfig
    {
        public string IpAddress { get; set; } = "192.168.0.145";
        public string Port { get; set; } = "80";
        public string DeviceUrl { get; set; } = "http://192.168.0.145";
        public string AppId { get; set; } = "accuid_dev";
        public string AppSecret { get; set; } = "accuid_dev_secret";
        public string ClientId { get; set; } = "DEV_1";
    }
}
