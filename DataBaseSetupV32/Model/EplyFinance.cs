using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class EplyFinance
    {
        public string EplyFinanceId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeFunllName { get; set; }
        public decimal TotalAmount { get; set; }
        public string MainComId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AccountingStatus { get; set; }
        public string TransBankingId { get; set; }
        public string TransBankingName { get; set; }
        public string TransferNo { get; set; }
        public string BankBusiness { get; set; }
        public bool IsClosed { get; set; }
        public int SettlePeriodMode { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string DepartmentId { get; set; }
        public string ContractorId { get; set; }
    }
}
