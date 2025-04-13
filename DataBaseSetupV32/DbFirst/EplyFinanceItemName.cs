using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class EplyFinanceItemName
    {
        public string EplyFinanceItemNameId { get; set; }
        public string AccountingCode { get; set; }
        public string ItemName { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        public int Status { get; set; }
        public string MainComId { get; set; }
    }
}
