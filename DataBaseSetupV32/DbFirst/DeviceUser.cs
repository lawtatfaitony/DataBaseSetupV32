using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class DeviceUser
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployName { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DevidceUserProfileId { get; set; }
        public string UserId { get; set; }
        public string AccessCardId { get; set; }
        public string FingerPrints { get; set; }
        public string PassKey { get; set; }
        public int SearchMode { get; set; }
        public string UserIconPositive { get; set; }
        public bool UserIconPositiveIsUpdate { get; set; }
        public string UserIconSide { get; set; }
        public bool UserIconSideIsUpdate { get; set; }
        public string UserIconTopView { get; set; }
        public bool UserIconTopViewIsUpdate { get; set; }
        public bool UserIconIsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool CreatedIsCompleted { get; set; }
        public int GeneralStatus { get; set; }
        public string SynchronizedStatusRemarks { get; set; }
        public int DownInsertStatus { get; set; }
        public DateTime DownInsertStatusDt { get; set; }
        public int DownUpdateStatus { get; set; }
        public DateTime DownUpdateStatusDt { get; set; }
        public int DownDelStatus { get; set; }
        public DateTime DownDelStatusDt { get; set; }
    }
}
