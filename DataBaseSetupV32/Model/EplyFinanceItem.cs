using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class EplyFinanceItem
    {
        public string EplyFinanceItemId { get; set; }
        public string EplyFinanceId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeFunllName { get; set; }
        public string ItemNameId { get; set; }
        public string ItemName { get; set; }
        public string AccountingCode { get; set; }
        public decimal Amount { get; set; }
        public string Summary { get; set; }
        public int DrorCr { get; set; }
        public DateTime OccuredDateTime { get; set; }
        public int AccountingStatus { get; set; }
        public int SettlePeriodMode { get; set; }
        public int IsClosed { get; set; }
        public string AccountingDocuments { get; set; }
        public string SubmitUser { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpDatedDateTime { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string Remarks { get; set; }
        public string MainComId { get; set; }
    }
}
