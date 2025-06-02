using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AttendanceBussiness.DbFirst
{
    public partial class AspNetPermissions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        /// <summary>
        /// 來自資料庫語言多語字典Language對應的KeyName,透過對KeyName的反射獲得當前多語言的值
        /// </summary>
        public string KeyName { get; set; }

        public string RoleClaims { get; set; }
       
        public string Description { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        /// <summary>
        /// 系統模組劃分為多個模組： 系統設定模組,排班與考勤設置模組,裝置與拍卡模組,考勤人員模組,請假與假期模組,考勤統計模組,薪酬與財務模組,薪資與財務統計模組,香港建造業模組,基礎數據模組  
        /// 1.系統設定模組 SystemSetting
        /// 2.排班與考勤設置模組 ShiftAndAttendance
        /// 3.裝置與拍卡模組 DeviceAndCard
        /// 4.考勤人員模組 AttendancePersonnel
        /// 5.請假與假期模組 LeaveAndHoliday
        /// 6.考勤統計模組 AttendanceStatistic
        /// 7.薪酬與財務模組 SalaryAndFinance
        /// 8.薪資與財務統計模組 SalaryAndFinanceStatistic
        /// 9.香港建造業模組 ConstructionIndustry
        /// 10.基礎數據模組 FoundationData
        /// </summary>
        public int Module { get; set; }
    }
}
