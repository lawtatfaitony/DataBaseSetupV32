using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
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
        public DateTime? UpdateDateTime { get; set; }
        public int Status { get; set; }
        public string SiteId { get; set; }
        public bool? IsReverseHex { get; set; }
        public string HangDownDevices { get; set; }
    }
}
