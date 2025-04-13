using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class SalTaxRate
    {
        public string SalTaxRateId { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public decimal Ratio { get; set; }
        public decimal Quota { get; set; }
        public decimal SocialInsuranceRatio { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public string MainComId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int SettlePeriodMode { get; set; }
    }
}
