﻿using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class ApproveFlowLog
    {
        public string ApproveFlowLogId { get; set; }
        public string ApproveFlowId { get; set; }
        public string PrimaryxKey { get; set; }
        public string TableName { get; set; }
        public string TableColumn { get; set; }
        public string ApprovalUserId { get; set; }
        public string ApprovalUserName { get; set; }
        public int ApprovalSequence { get; set; }
        public int Status { get; set; }
        /// <summary>
        /// ApproveFlowLog.Status  判斷上一個節點 ApproveFlowLog.TargetResult是否和下一個節點的ApproveFlowLog.TargetResult 是否一致. 
        /// </summary>
        public int TargetResult { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public bool IsUndo { get; set; }
        public DateTime? UndoTime { get; set; }
        public string SourceRowHash { get; set; }
        public string Remarks { get; set; }
        public string MainComId { get; set; }
    }
}
