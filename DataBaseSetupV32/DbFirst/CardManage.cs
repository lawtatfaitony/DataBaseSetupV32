using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class CardManage
    {
        public string Id { get; set; }
        public string PhysicalId { get; set; }
        public string CardNo { get; set; }
        public string OccupiedByEmployeeId { get; set; }
        public string OccupiedByEmployeeName { get; set; }
        public string MapToUserDeviceSerialNo { get; set; }
        public string MainComId { get; set; }
        public int Status { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string OperatedUser { get; set; }
        public string ContractorId { get; set; }
    }
}
