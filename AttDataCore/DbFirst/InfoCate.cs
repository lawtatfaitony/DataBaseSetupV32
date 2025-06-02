using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class InfoCate
    {
        public string InfoCateID { get; set; }
        public string MainComId { get; set; }
        public string PrarentsID { get; set; }
        public string InfoCateName { get; set; }
        public int Levels { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string LanguageCode { get; set; }
    }
}
