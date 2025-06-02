using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class LeaveTypeDay
    {
        /// <summary>
        /// Auto-increment ID 使用 函数 DataBaseContext.GetTableIdentityID
        /// </summary>
        public string LeaveTypeDayId { get; set; }
        public string MainComId { get; set; }
        /// <summary>
        /// MainComId 和 LeaveType 确定唯一的记录，例如定义 公司6000014的年假10天
        /// </summary>
        public string LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        /// <summary>
        /// 累計的時長：例如基於自然天數10天年假計算，則最大MaxLeaveDaySpan = 10自然天*GlobalConfig.StandardWorkDaySpan(默認8小時) = 80小時
        /// </summary>
        public float MaxLeaveDaySpan { get; set; }
        /// <summary>
        /// 如 3-8婦女節 半天假期 = 0.5 個工作日 換算成 MaxLeaveDaySpan =  0.5*GlobalConfig.StandardWorkDaySpan(8小時) 即4小時 
        /// </summary>
        public float MaxLeaveNatureWorkDay { get; set; }
        /// <summary>
        /// 是否允許累計 如果統計總的請假天數則視乎此值. 例如 設置三天 只能一次性用完配額，不能累計的意思。例如 侍產假 只能1次 最多三天，如果請假了兩天則視為已經用完Quota
        /// </summary>
        public bool IsForTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string OperatedUser { get; set; }
    }
}
