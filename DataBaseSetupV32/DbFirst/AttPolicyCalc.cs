using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class AttPolicyCalc
    {
        public string AttPolicyCalcId { get; set; }
        public int SettlePeriodMode { get; set; }
        public DateTime DateTimeForRpt { get; set; }
        public string PolicyConfigLog { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public int DrorCr { get; set; }
        public decimal Amount { get; set; }
        public DateTime CalcDateTime { get; set; }
        public int AccountingComplete { get; set; }
        public string ComfirmeddBy { get; set; }
        public int ApprovedStatus { get; set; }
        public string MainComId { get; set; }
        public DateTime OperateDateTime { get; set; }
    }
}
