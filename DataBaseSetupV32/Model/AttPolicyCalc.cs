using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class AttPolicyCalc
    {
        /// <summary>
        /// 改用 對應 常量ShiftBusiness.ApprovedMode 但column name 保留不變, 2025-3-1, 功能:審批 拒絕 取消等狀態
        /// </summary>
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
        /// <summary>
        /// OPEN=1
        /// </summary>
        public int AccountingComplete { get; set; }
        public string ComfirmeddBy { get; set; }
        /// <summary>
        /// GeneralStatus 改為 ApprovedStatus 常量值是 ShiftBusiness.ApprovedMode
        /// </summary>
        public int ApprovedStatus { get; set; }
        public string MainComId { get; set; }
        public DateTime OperateDateTime { get; set; }
    }
}
