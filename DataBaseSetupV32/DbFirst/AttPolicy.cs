using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class AttPolicy
    {
        public string AttPolicyId { get; set; }
        public string AttPolicyLabelName { get; set; }
        public string PolicyConfig { get; set; }
        public int Status { get; set; }
        public int SettlePeriodMode { get; set; }
        public string OperatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string RuleDescription { get; set; }
        public string MainComId { get; set; }
        public int AttPolicyConfigCalcMode { get; set; }
    }
}
