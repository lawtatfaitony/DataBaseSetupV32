using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class SalaryAndFinanceSecurity
    {
        public string SalaryAndFinanceSecurityId { get; set; }
        public string TargetTableName { get; set; }
        public string TargetPrimaryKey { get; set; }
        public string HamcResult { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
    }
}
