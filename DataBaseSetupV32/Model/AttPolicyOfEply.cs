using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class AttPolicyOfEply
    {
        public string AttPolicyOfEplyId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string AttPolicyId { get; set; }
        public string AttPolicyLabelName { get; set; }
        public string PolicyConfig { get; set; }
        public int SettlePeriodMode { get; set; }
        public string OperatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime OperateDateTime { get; set; }
        public int Status { get; set; }
        public string MainComId { get; set; }
    }
}
