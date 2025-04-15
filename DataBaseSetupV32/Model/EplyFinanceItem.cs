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
        /// <summary>
        ///  = EplyFinanceItemNameId
        /// </summary>
        public string ItemNameId { get; set; }
        /// <summary>
        /// Item Name : BusFee  LunchFee
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 會計記賬代碼 Accounting Code
        /// </summary>
        public string AccountingCode { get; set; }
        public decimal Amount { get; set; }
        public string Summary { get; set; }
        /// <summary>
        /// 借或者贷
        /// </summary>
        public int DrorCr { get; set; }
        public DateTime OccuredDateTime { get; set; }
        /// <summary>
        /// 会计状态
        /// </summary>
        public int AccountingStatus { get; set; }
        public int SettlePeriodMode { get; set; }
        public int IsClosed { get; set; }
        public string AccountingDocuments { get; set; }
        /// <summary>
        /// 提交申請者(USER)
        /// </summary>
        public string SubmitUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpDatedDateTime { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        /// <summary>
        /// 系統使用的 json數據結果
        /// </summary>
        public string Remarks { get; set; }
        public string MainComId { get; set; }
    }
}
