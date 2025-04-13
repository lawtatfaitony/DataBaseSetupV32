using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class LeaveTypeDay
    {
        public string LeaveTypeDayId { get; set; }
        public string MainComId { get; set; }
        public string LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public byte[] MaxLeaveDaySpan { get; set; }
        public decimal MaxLeaveNatureWorkDay { get; set; }
        public bool? IsForTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string OperatedUser { get; set; }
    }
}
