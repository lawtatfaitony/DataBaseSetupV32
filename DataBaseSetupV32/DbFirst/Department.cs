using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.DbFirst
{
    public partial class Department
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EnDepartmentName { get; set; }
        public string DepartmentAbbrName { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string IndustryId { get; set; }
        public string UserIds { get; set; }
        public bool? IsActive { get; set; }
        public string ParantsDeptId { get; set; }
        public string ParentsDeptName { get; set; }
        public int Sequence { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
    }
}
