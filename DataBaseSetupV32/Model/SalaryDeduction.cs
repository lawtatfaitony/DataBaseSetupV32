using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class SalaryDeduction
    {
        public string SalaryDeductionId { get; set; }
        public int SettlePeriodMode { get; set; }
        public DateTime StartDate { get; set; }
        public string AttendanceByPeriodId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public int DrorCr { get; set; }
        public decimal Amount { get; set; }
        public decimal SalaryAssessmentValue { get; set; }
        public decimal AvgOnDutyWorkRatio { get; set; }
        public decimal AvgOnDutyPaidRatio { get; set; }
        public decimal OverAllCompletedRatio { get; set; }
        public DateTime CalcDateTime { get; set; }
        /// <summary>
        /// OPEN=1
        /// </summary>
        public int AccountingComplete { get; set; }
        /// <summary>
        /// GeneralStatus (ACTIVE=1;INACTIVE = 0) 
        /// </summary>
        public int GeneralStatus { get; set; }
        public string MainComId { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
    }
}
