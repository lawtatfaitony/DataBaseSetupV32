using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class SalWelfareCalc
    {
        public string SalWelfareCalcId { get; set; }
        public int SettlePeriodMode { get; set; }
        public string EplyFinanceItemNameId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeFunllName { get; set; }
        public int DrorCr { get; set; }
        public string CalcBusinessDesc { get; set; }
        public string ApprovedBy { get; set; }
        public int? ApprovedStatus { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string MainComId { get; set; }
    }
}
