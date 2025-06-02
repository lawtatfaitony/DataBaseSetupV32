using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class ApproveFlow
    {
        public string ApproveFlowId { get; set; }
        public int ApprovalSequence { get; set; }
        public string TableName { get; set; }
        public string TableColumn { get; set; }
        public string ApprovalUserIds { get; set; }
        /// <summary>
        /// 如果只局限於部門審批,則不指定審批用戶ID,或者作為備審人員 來源 Department.UserId
        /// </summary>
        public bool AprovedByDeptSupervisor { get; set; }
        public int Status { get; set; }
        /// <summary>
        /// 多用戶審批流程---啟動日期[Startup Datetime]: 把之前單用戶審批分開處理的時間起點。
        /// </summary>
        public DateTime StartupDatetime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public TimeSpan CoolingOffBefore { get; set; }
        public string MainComId { get; set; }
    }
}
