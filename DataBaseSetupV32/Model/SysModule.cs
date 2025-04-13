using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class SysModule
    {
        public string KeyId { get; set; }
        public string SysModuleId { get; set; }
        public string SysModuleName { get; set; }
        public string Config { get; set; }
        public string FuncDesc { get; set; }
        public int SysModuleType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GeneralStatus { get; set; }
        public string MainComId { get; set; }
    }
}
