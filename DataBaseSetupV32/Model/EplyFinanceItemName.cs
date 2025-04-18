﻿using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class EplyFinanceItemName
    {
        public string EplyFinanceItemNameId { get; set; }
        /// <summary>
        /// 會計記賬代碼 Accounting Code
        /// </summary>
        public string AccountingCode { get; set; }
        public string ItemName { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        public int Status { get; set; }
        public string MainComId { get; set; }
    }
}
