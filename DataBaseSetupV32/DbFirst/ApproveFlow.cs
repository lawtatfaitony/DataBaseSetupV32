using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class ApproveFlow
    {
        public string ApproveFlowId { get; set; }
        public int ApprovalSequence { get; set; }
        public string TableName { get; set; }
        public string TableColumn { get; set; }
        public string ApprovalUserIds { get; set; }
        public bool AprovedByDeptSupervisor { get; set; }
        public int Status { get; set; }
        public DateTime StartupDatetime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public TimeSpan CoolingOffBefore { get; set; }
        public string MainComId { get; set; }
    }
}
