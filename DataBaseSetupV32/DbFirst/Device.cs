using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Device
    {
        public string DeviceId { get; set; }
        public string SysModuleId { get; set; }
        public string DeviceName { get; set; }
        public int DeviceEntryMode { get; set; }
        public string DeviceSerialNo { get; set; }
        public string Config { get; set; }
        public string MainComId { get; set; }
        public string OperatedUser { get; set; }
        public DateTime UpdateDateTime { get; set; }
        /// <summary>
        /// 0 = not ; 2 = applicable ; 2 =  active inactive
        /// </summary>
        public int Status { get; set; }
        public string SiteId { get; set; }
        public bool IsReverseHex { get; set; }
        /// <summary>
        /// DEV  JSON LIST 設備載體平台的 下掛設備 utf-8 編碼文字
        /// </summary>
        public string HangDownDevices { get; set; }
    }
}
