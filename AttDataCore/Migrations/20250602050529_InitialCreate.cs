using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceBussiness.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApproveFlow",
                columns: table => new
                {
                    ApproveFlowId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ApprovalSequence = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TableColumn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ApprovalUserIds = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    AprovedByDeptSupervisor = table.Column<bool>(type: "bit", nullable: false, comment: "如果只局限於部門審批,則不指定審批用戶ID,或者作為備審人員 來源 Department.UserId"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartupDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "多用戶審批流程---啟動日期[Startup Datetime]: 把之前單用戶審批分開處理的時間起點。"),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CoolingOffBefore = table.Column<TimeSpan>(type: "time", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproveFlow", x => x.ApproveFlowId);
                });

            migrationBuilder.CreateTable(
                name: "ApproveFlowLog",
                columns: table => new
                {
                    ApproveFlowLogId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ApproveFlowId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PrimaryxKey = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    TableName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TableColumn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ApprovalUserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ApprovalUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovalSequence = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TargetResult = table.Column<int>(type: "int", nullable: false, comment: "ApproveFlowLog.Status  判斷上一個節點 ApproveFlowLog.TargetResult是否和下一個節點的ApproveFlowLog.TargetResult 是否一致. "),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsUndo = table.Column<bool>(type: "bit", nullable: false),
                    UndoTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    SourceRowHash = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproveFlowLog", x => x.ApproveFlowLogId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetPermissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    KeyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "來自資料庫語言多語字典Language對應的KeyName,透過對KeyName的反射獲得當前多語言的值"),
                    RoleClaims = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "新儲存的角色聲明，與Table AspNetRoleClaims 互補"),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))", comment: "SystemModule系統模組劃分為多個模組： 1.系統設定模組 SystemSetting, 2.排班與考勤設置模組 ShiftAndAttendance, 3.裝置與拍卡模組 DeviceAndCard,4.考勤人員模組 AttendancePersonnel,5.請假與假期模組 LeaveAndHoliday,6.考勤統計模組 AttendanceStatistic,7.薪酬與財務模組 SalaryAndFinance,8.薪資與財務統計模組 SalaryAndFinanceStatistic,9.香港建造業模組 ConstructionIndustry,10.基礎數據模組 FoundationData")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceByCom",
                columns: table => new
                {
                    AttendanceByComId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalEmployeesInAttendance = table.Column<int>(type: "int", nullable: false),
                    TotalActualNetWorkDay = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfLateIn = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfEarlyOut = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularWorkOn = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularWorkOff = table.Column<int>(type: "int", nullable: false),
                    TotalAbsentDays = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfMissing = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfAttendance = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfOverTime = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfBreak = table.Column<int>(type: "int", nullable: false),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false),
                    SysCalcDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceByCom", x => x.AttendanceByComId);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceByDay",
                columns: table => new
                {
                    AttendanceByDayId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractorId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsWorkDay = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsentDay = table.Column<bool>(type: "bit", nullable: false),
                    DayShiftNameList = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DayShiftListJson = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DayTotalWorkTimeSpan = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayTotalWorkNetTimeSpan = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "('00:00:00.0000000')"),
                    DayTotalLunchTimeSpan = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "('00:00:00.0000000')"),
                    DayTotalOverTimeSpan = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "('00:00:00.0000000')"),
                    DayLateInTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayIsLateTimez = table.Column<int>(type: "int", nullable: false),
                    DayEarlyOutTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayIsEarlyTimez = table.Column<int>(type: "int", nullable: false),
                    DayLunchLateInTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayLunchIsLateTimez = table.Column<int>(type: "int", nullable: false),
                    DayLunchEarlyOutTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayLunchIsEarlyTimez = table.Column<int>(type: "int", nullable: false),
                    DayOverTimeLateInTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayOverTimeIsLateTimez = table.Column<int>(type: "int", nullable: false),
                    DayOverTimeEarlyOutTimeSpan = table.Column<int>(type: "int", nullable: false),
                    DayOverTimeIsEarlyTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingWorkOnTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingWorkOffTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingLunchStartTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingLunchEndTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingOverTimeStartTimez = table.Column<int>(type: "int", nullable: false),
                    DayMissingOverTimeEndTimez = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularWorkOn = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularWorkOff = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularLunchStart = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularLunchEnd = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularOverTimeStart = table.Column<int>(type: "int", nullable: false),
                    TotalTimesOfRegularOverTimeEnd = table.Column<int>(type: "int", nullable: false),
                    LeaveId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LeavePaidType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    LeavePaidTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LeaveWithPaidRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HolidayId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    HolidayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HolidayPaidType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    HolidayPaidTypeName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    HolidayWithPaidRatio = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
                    OnDutyWorkRatioAvg = table.Column<decimal>(type: "decimal(18,3)", nullable: false, defaultValueSql: "((1))"),
                    OnDutyPaidRatioAvg = table.Column<decimal>(type: "decimal(18,3)", nullable: false, defaultValueSql: "((1))"),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SysCalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OccurDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    HmacHash = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceByDay", x => x.AttendanceByDayId);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceByPeriod",
                columns: table => new
                {
                    AttendanceByPeriodId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    Mode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    ObjectData = table.Column<string>(type: "ntext", nullable: true),
                    ShiftNameStructure = table.Column<string>(type: "ntext", nullable: true),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))"),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractorId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvgWorkActualNetTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuWorkActualNetTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AvgWorkTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuWorkTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AvgLunchTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuLunchTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AvgOverTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuOverTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuLeaveDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccuHolidays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccuWorkDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccuAbsentDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccuTimesOfLateIn = table.Column<int>(type: "int", nullable: false),
                    AccuLateInTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfEarlyOut = table.Column<int>(type: "int", nullable: false),
                    AccuEarlyOutTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfLunchLateIn = table.Column<int>(type: "int", nullable: false),
                    AccuLunchLateInTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfLunchEarlyOut = table.Column<int>(type: "int", nullable: false),
                    AccuEarlyLunchOutTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfOverTimeLateIn = table.Column<int>(type: "int", nullable: false),
                    AccuOverTimeLateInTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfOverTimeEarlyOut = table.Column<int>(type: "int", nullable: false),
                    AccuEarlyOverTimeOutTimeSpan = table.Column<long>(type: "bigint", nullable: false),
                    AccuTimesOfRegular = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularWorkOn = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularWorkOff = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularLunchStart = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularLunchEnd = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularOverTimeStart = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfRegularOverTimeEnd = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissing = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingWorkOn = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingWorkOff = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingLunchStart = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingLunchEnd = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingOverTimeStart = table.Column<int>(type: "int", nullable: false),
                    AccuTimesOfMissingOverTimeEnd = table.Column<int>(type: "int", nullable: false),
                    AvgOnDutyWorkRatio = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AvgOnDutyPaidRatio = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AvgAttWeightedRatio = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValueSql: "((1))", comment: "加權平均考勤率：加權平均法計算出這個時期的平均加權考勤率"),
                    PresetWorkTimeSpan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OverAllCompletedRatio = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "總體完成率 是指實際確切的工作時間減去應工作的排班時間 如週期(月度)結束,合理情況是100%"),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    SysCalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    HmacHash = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceByPeriod", x => x.AttendanceByPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceByShift",
                columns: table => new
                {
                    AttendanceByShiftId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ObjData = table.Column<string>(type: "ntext", nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    ShiftId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "((0))"),
                    ShiftAbbrId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ShiftName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ScheduleDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractorId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsWorkDay = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsentDay = table.Column<bool>(type: "bit", nullable: false),
                    WorkStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    WorkEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    LateIn = table.Column<int>(type: "int", nullable: false),
                    IsLate = table.Column<int>(type: "int", nullable: false),
                    EarlyOut = table.Column<int>(type: "int", nullable: false),
                    IsEarly = table.Column<int>(type: "int", nullable: false),
                    WorkTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkActualNetTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverTimeStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    OverTimeEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    OverTimeLateIn = table.Column<int>(type: "int", nullable: false),
                    OverTimeIsLate = table.Column<int>(type: "int", nullable: false),
                    OverTimeEarlyOut = table.Column<int>(type: "int", nullable: false),
                    OverTimeIsEarly = table.Column<int>(type: "int", nullable: false),
                    BreakTimes = table.Column<int>(type: "int", nullable: false),
                    BreakTimeTotalSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchTimeStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    LunchTimeEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    LunchTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchTimeLateIn = table.Column<int>(type: "int", nullable: false),
                    LunchTimeIsLate = table.Column<int>(type: "int", nullable: false),
                    LunchTimeEarlyOut = table.Column<int>(type: "int", nullable: false),
                    LunchTimeIsEarly = table.Column<int>(type: "int", nullable: false),
                    IsAutoCalcMissing = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularWorkOn = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularWorkOff = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularLunchStart = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularLunchEnd = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularOverTimeStart = table.Column<bool>(type: "bit", nullable: false),
                    IsRegularOverTimeEnd = table.Column<bool>(type: "bit", nullable: false),
                    MissingWorkOn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    MissingWorkOff = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    MissingLunchStart = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    MissingLunchEnd = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    MissingOverTimeStart = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    MissingOverTimeEnd = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    LeaveId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LeavePaidType = table.Column<int>(type: "int", nullable: false),
                    LeavePaidTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HolidayId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HolidayPaidType = table.Column<int>(type: "int", nullable: false),
                    HolidayPaidTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    OnDutyWorkRatio = table.Column<decimal>(type: "decimal(18,3)", nullable: false, defaultValueSql: "((1))"),
                    OnDutyPaidRatio = table.Column<decimal>(type: "decimal(18,3)", nullable: false, defaultValueSql: "((1))"),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SysCalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    HmacHash = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceByShift", x => x.AttendanceByShiftId);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceLog",
                columns: table => new
                {
                    AttendanceLogId = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "((-1))"),
                    Mode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    ObjData = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceEntryMode = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AccesscardId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CnName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OccurDateTime = table.Column<long>(type: "bigint", nullable: false),
                    CatchPictureFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SiteId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CratedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CatchPicture = table.Column<string>(type: "text", nullable: true),
                    FacialArea = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    FacialAvatar = table.Column<string>(type: "text", nullable: true),
                    LatitudeAndLongitude = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HmacHash = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceLog", x => x.AttendanceLogId);
                });

            migrationBuilder.CreateTable(
                name: "AttLog",
                columns: table => new
                {
                    AttendanceLogId = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "((-1))"),
                    Mode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    ObjData = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceEntryMode = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AccesscardId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CnName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OccurDateTime = table.Column<long>(type: "bigint", nullable: false),
                    CatchPictureFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SiteId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CratedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CatchPicture = table.Column<string>(type: "text", nullable: true),
                    FacialArea = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    FacialAvatar = table.Column<string>(type: "text", nullable: true),
                    LatitudeAndLongitude = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HmacHash = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttLog", x => x.AttendanceLogId);
                });

            migrationBuilder.CreateTable(
                name: "AttPolicy",
                columns: table => new
                {
                    AttPolicyId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    AttPolicyLabelName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PolicyConfig = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((3))"),
                    OperatedUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    RuleDescription = table.Column<string>(type: "ntext", nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AttPolicyConfigCalcMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttPolicy", x => x.AttPolicyId);
                });

            migrationBuilder.CreateTable(
                name: "AttPolicyCalc",
                columns: table => new
                {
                    AttPolicyCalcId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false, comment: "改用 對應 常量ShiftBusiness.ApprovedMode 但column name 保留不變, 2025-3-1, 功能:審批 拒絕 取消等狀態"),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    DateTimeForRpt = table.Column<DateTime>(type: "datetime", nullable: false),
                    PolicyConfigLog = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrorCr = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountingComplete = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: "OPEN=1"),
                    ComfirmeddBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: "GeneralStatus 改為 ApprovedStatus 常量值是 ShiftBusiness.ApprovedMode"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttPolicyCalc", x => x.AttPolicyCalcId);
                });

            migrationBuilder.CreateTable(
                name: "AttPolicyOfEply",
                columns: table => new
                {
                    AttPolicyOfEplyId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AttPolicyId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    AttPolicyLabelName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PolicyConfig = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((3))"),
                    OperatedUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttPolicyOfEply", x => x.AttPolicyOfEplyId);
                });

            migrationBuilder.CreateTable(
                name: "CardManage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PhysicalId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CardNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    OccupiedByEmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OccupiedByEmployeeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MapToUserDeviceSerialNo = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "0 = not ; 2 = applicable ; 2 =  active inactive"),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardManage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIds = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNameLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorId);
                });

            migrationBuilder.CreateTable(
                name: "DefinitedPeriod",
                columns: table => new
                {
                    DefinitedPeriodId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DefinitedPeriodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    OperatedUserName = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinitedPeriod", x => x.DefinitedPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EnDepartmentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DepartmentAbbrName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserIds = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "不允許NULL 不允許DEFAULT VALUE"),
                    ParantsDeptId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ParentsDeptName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SysModuleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeviceEntryMode = table.Column<int>(type: "int", nullable: false),
                    DeviceSerialNo = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OperatedUser = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "0 = not ; 2 = applicable ; 2 =  active inactive"),
                    SiteId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsReverseHex = table.Column<bool>(type: "bit", nullable: false),
                    HangDownDevices = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true, comment: "DEV  JSON LIST 設備載體平台的 下掛設備 utf-8 編碼文字")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DevidceUserProfileId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AccessCardId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    FingerPrints = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    PassKey = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    SearchMode = table.Column<int>(type: "int", nullable: false),
                    UserIconPositive = table.Column<string>(type: "text", nullable: true),
                    UserIconPositiveIsUpdate = table.Column<bool>(type: "bit", nullable: false),
                    UserIconSide = table.Column<string>(type: "text", nullable: true),
                    UserIconSideIsUpdate = table.Column<bool>(type: "bit", nullable: false),
                    UserIconTopView = table.Column<string>(type: "text", nullable: true),
                    UserIconTopViewIsUpdate = table.Column<bool>(type: "bit", nullable: false),
                    UserIconIsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedIsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    GeneralStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    SynchronizedStatusRemarks = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    DownInsertStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    DownInsertStatusDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DownUpdateStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    DownUpdateStatusDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DownDelStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
                    DownDelStatusDt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    The3rdPartyEmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ParentUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserIcon = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CnName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SiteId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AccessCardId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    FingerPrint = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EplyFinance",
                columns: table => new
                {
                    EplyFinanceId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeFunllName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountingStatus = table.Column<int>(type: "int", nullable: false, comment: "会计状态"),
                    TransBankingId = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    TransBankingName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TransferNo = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    BankBusiness = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, comment: "settle  account"),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    OperatedUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EplyFinance", x => x.EplyFinanceId);
                });

            migrationBuilder.CreateTable(
                name: "EplyFinanceItem",
                columns: table => new
                {
                    EplyFinanceItemId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EplyFinanceId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeFunllName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ItemNameId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false, comment: " = EplyFinanceItemNameId"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Item Name : BusFee  LunchFee"),
                    AccountingCode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, comment: "會計記賬代碼 Accounting Code"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    DrorCr = table.Column<int>(type: "int", nullable: false, comment: "借或者贷"),
                    OccuredDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountingStatus = table.Column<int>(type: "int", nullable: false, comment: "会计状态"),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<int>(type: "int", nullable: false),
                    AccountingDocuments = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true, defaultValueSql: "(N'上存會計文件保存 文件名分號隔開的數組字符串')"),
                    SubmitUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "提交申請者(USER)"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpDatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OperatedUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true, comment: "系統使用的 json數據結果"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EplyFinanceItem", x => x.EplyFinanceItemId);
                });

            migrationBuilder.CreateTable(
                name: "EplyFinanceItemName",
                columns: table => new
                {
                    EplyFinanceItemNameId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    AccountingCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "會計記賬代碼 Accounting Code"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperatedUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EplyFinanceItemName", x => x.EplyFinanceItemNameId);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    EventLogId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    OperateLogContent = table.Column<string>(type: "ntext", nullable: true),
                    MessageIfException = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    OperateDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OperateUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, defaultValueSql: "(N'SYSTEM')"),
                    EventDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.EventLogId);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    HolidayId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HolidayCnName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HolidayEnName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HolidayDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsWholeDay = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    StatutoryHoliday = table.Column<bool>(type: "bit", nullable: true),
                    HolidayPaidType = table.Column<int>(type: "int", nullable: false),
                    HolidayPaidTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnDutyPaidRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    IndustryId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnIndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentsIndustryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "InfoCate",
                columns: table => new
                {
                    InfoCateID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrarentsID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InfoCateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: false),
                    OperatedUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoCate", x => x.InfoCateID);
                });

            migrationBuilder.CreateTable(
                name: "InfoDetail",
                columns: table => new
                {
                    InfoId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InfoCateId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TitleThumbNail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ShowTitleThumbNail = table.Column<bool>(type: "bit", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InfoDescription = table.Column<string>(type: "ntext", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    InfoItemTemplateIds = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: false),
                    UserTraceId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.InfoDetail", x => x.InfoId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    The3rdJobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnJobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((190605))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    KeyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    KeyType = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    zh_CN = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    zh_HK = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    en_US = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    IndustryIdArr = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    MainComIdArr = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Chinese_Taiwan_Stroke_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.KeyName);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    LeaveId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, comment: "allow the array or  Single"),
                    EmployeeId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalDaySpan = table.Column<double>(type: "float", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((0))"),
                    Reason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedRemarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ApplovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovedDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "審批的日期時間"),
                    OperatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LeavePaidType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.LeaveId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeDay",
                columns: table => new
                {
                    MainComId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "MainComId 和 LeaveType 确定唯一的记录，例如定义 公司6000014的年假10天"),
                    LeaveTypeDayId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Auto-increment ID 使用 函数 DataBaseContext.GetTableIdentityID"),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxLeaveDaySpan = table.Column<double>(type: "float", nullable: false, comment: "累計的時長：例如基於自然天數10天年假計算，則最大MaxLeaveDaySpan = 10自然天*GlobalConfig.StandardWorkDaySpan(默認8小時) = 80小時"),
                    MaxLeaveNatureWorkDay = table.Column<double>(type: "float", nullable: false, comment: "如 3-8婦女節 半天假期 = 0.5 個工作日 換算成 MaxLeaveDaySpan =  0.5*GlobalConfig.StandardWorkDaySpan(8小時) 即4小時 "),
                    IsForTotal = table.Column<bool>(type: "bit", nullable: false, comment: "是否允許累計 如果統計總的請假天數則視乎此值. 例如 設置三天 只能一次性用完配額，不能累計的意思。例如 侍產假 只能1次 最多三天，如果請假了兩天則視為已經用完Quota"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeDay", x => new { x.LeaveType, x.MainComId });
                });

            migrationBuilder.CreateTable(
                name: "MainCom",
                columns: table => new
                {
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceStatus = table.Column<int>(type: "int", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCom", x => x.MainComId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MenuItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngMenuItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentsMenuItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ParentsNodeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, defaultValueSql: "((0))", comment: "default value = 0 (IsParentsNode)"),
                    IndustryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnPositionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryAndFinanceSecurity",
                columns: table => new
                {
                    SalaryAndFinanceSecurityId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    TargetTableName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    TargetPrimaryKey = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    HamcResult = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAndFinanceSecurity", x => x.SalaryAndFinanceSecurityId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDeduction",
                columns: table => new
                {
                    SalaryDeductionId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AttendanceByPeriodId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractorId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrorCr = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryAssessmentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvgOnDutyWorkRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvgOnDutyPaidRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverAllCompletedRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountingComplete = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: "OPEN=1"),
                    GeneralStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: "GeneralStatus (ACTIVE=1;INACTIVE = 0) "),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDeduction", x => x.SalaryDeductionId);
                });

            migrationBuilder.CreateTable(
                name: "SalAssessment",
                columns: table => new
                {
                    SalAssessmentId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    EmployeeFunllName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SalaryAssessmentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormulaOfAssessment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedUser = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalAssessment", x => x.SalAssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "SalTaxRate",
                columns: table => new
                {
                    SalTaxRateId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Ratio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quota = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "priority to use Ratio , if Ratio is zero then use the Quota."),
                    SocialInsuranceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((3))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalTaxRate", x => x.SalTaxRateId);
                });

            migrationBuilder.CreateTable(
                name: "SalWelfareCalc",
                columns: table => new
                {
                    SalWelfareCalcId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SettlePeriodMode = table.Column<int>(type: "int", nullable: false),
                    EplyFinanceItemNameId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmployeeFunllName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DrorCr = table.Column<int>(type: "int", nullable: false),
                    CalcBusinessDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: false),
                    OperateDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalWelfareCalc", x => x.SalWelfareCalcId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    IdOfMonthlyShiftEmploy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ShiftId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShiftAbbrId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    ShiftAssignedMode = table.Column<int>(type: "int", nullable: false),
                    WorkStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SysCalcDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValueSql: "((6))"),
                    ShiftAbbrId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IconColor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('FC0366')"),
                    ShiftName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShiftBusinessMode = table.Column<int>(type: "int", nullable: false),
                    ShiftAppliedMode = table.Column<int>(type: "int", nullable: false),
                    DepartmentIdArr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WorkTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkStartAllowance = table.Column<int>(type: "int", nullable: false),
                    WorkEndAllowance = table.Column<int>(type: "int", nullable: false),
                    WorkStartBuffer = table.Column<int>(type: "int", nullable: false),
                    WorkEndBuffer = table.Column<int>(type: "int", nullable: false),
                    SpecialWeekDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpecialWeekDaysWorkStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    SpecialWeekDaysWorkEnd = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "(getdate())"),
                    ExcludeWeekDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcludeOverTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverTimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    OverTimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    OverTimeStartBuffer = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((60))"),
                    OverTimeEndBuffer = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((60))"),
                    LunchTimeSpan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchTimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    LunchTimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    LunchTimeStartBuffer = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((30))"),
                    LunchTimeEndBuffer = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((30))"),
                    BreakTimeSpan = table.Column<int>(type: "int", nullable: false),
                    BreakTimeCalcStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakTimeCalcEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakTimeAllowance = table.Column<int>(type: "int", nullable: false),
                    IsAutoCalcMissing = table.Column<bool>(type: "bit", nullable: false),
                    MissingWorkOn = table.Column<int>(type: "int", nullable: false),
                    MissingWorkOff = table.Column<int>(type: "int", nullable: false),
                    MissingLunchStart = table.Column<int>(type: "int", nullable: false),
                    MissingLunchEnd = table.Column<int>(type: "int", nullable: false),
                    MissingOverTimeStart = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    MissingOverTimeEnd = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    AppliedStartDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    AppliedEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    RuleDescription = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatedUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SiteAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "SourceStatistic",
                columns: table => new
                {
                    SourceStatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SourceArea = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loadTime = table.Column<int>(type: "int", nullable: false),
                    OSVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TableKeyId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, defaultValueSql: "('')"),
                    RecommUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VisitorIcon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    WxNickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OpenId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SourceStatistic", x => x.SourceStatisticsId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Qrcode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContactTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Introduction = table.Column<string>(type: "ntext", nullable: true),
                    ChannelID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OtherChannelName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OtherQrcode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IconPortrait = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PublicNo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "SysModule",
                columns: table => new
                {
                    KeyId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SysModuleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SysModuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Config = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    FuncDesc = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    SysModuleType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    GeneralStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysModule", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "TableIdentity",
                columns: table => new
                {
                    TableName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableIdentityId = table.Column<int>(type: "int", nullable: false),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TableIdentity", x => x.TableName);
                });

            migrationBuilder.CreateTable(
                name: "TaskJob",
                columns: table => new
                {
                    TaskJobId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TargetTalbeKeyId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TriggerDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    OnDataLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskJob", x => x.TaskJobId);
                });

            migrationBuilder.CreateTable(
                name: "TaskSetting",
                columns: table => new
                {
                    TaskSettingId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CalcPeriodType = table.Column<int>(type: "int", nullable: false),
                    CalcPeriodSpan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((60))"),
                    TaskRuningStartTime = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "(getdate())"),
                    TaskRuningEndTime = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "(getdate())"),
                    TimesOfTaskRunning = table.Column<int>(type: "int", nullable: false),
                    TaskStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TaskRemarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSetting", x => x.TaskSettingId);
                });

            migrationBuilder.CreateTable(
                name: "TransferObjectList",
                columns: table => new
                {
                    TransferObjectListId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HolderId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    HolderRfId = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    ObjectId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ObjectRfId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "对应AccessCardId"),
                    StorageState = table.Column<int>(type: "int", nullable: false),
                    ObjectLogDateTime = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferObjectList", x => x.TransferObjectListId);
                });

            migrationBuilder.CreateTable(
                name: "UploadItem",
                columns: table => new
                {
                    UploadItemId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TargetTalbeKeyId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RawName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileExt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RankOrder = table.Column<int>(type: "int", nullable: false),
                    OperatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadItem", x => x.UploadItemId);
                });

            migrationBuilder.CreateTable(
                name: "UserTrace",
                columns: table => new
                {
                    UserTraceID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableKeyID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MainComId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OperatedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OperatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrace", x => x.UserTraceID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "PK_AspNetPermissions",
                table: "AspNetPermissions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_EplyFinanceId",
                table: "EplyFinance",
                column: "EplyFinanceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApproveFlow");

            migrationBuilder.DropTable(
                name: "ApproveFlowLog");

            migrationBuilder.DropTable(
                name: "AspNetPermissions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceByCom");

            migrationBuilder.DropTable(
                name: "AttendanceByDay");

            migrationBuilder.DropTable(
                name: "AttendanceByPeriod");

            migrationBuilder.DropTable(
                name: "AttendanceByShift");

            migrationBuilder.DropTable(
                name: "AttendanceLog");

            migrationBuilder.DropTable(
                name: "AttLog");

            migrationBuilder.DropTable(
                name: "AttPolicy");

            migrationBuilder.DropTable(
                name: "AttPolicyCalc");

            migrationBuilder.DropTable(
                name: "AttPolicyOfEply");

            migrationBuilder.DropTable(
                name: "CardManage");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "DefinitedPeriod");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceUser");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EplyFinance");

            migrationBuilder.DropTable(
                name: "EplyFinanceItem");

            migrationBuilder.DropTable(
                name: "EplyFinanceItemName");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "InfoCate");

            migrationBuilder.DropTable(
                name: "InfoDetail");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "LeaveTypeDay");

            migrationBuilder.DropTable(
                name: "MainCom");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "SalaryAndFinanceSecurity");

            migrationBuilder.DropTable(
                name: "SalaryDeduction");

            migrationBuilder.DropTable(
                name: "SalAssessment");

            migrationBuilder.DropTable(
                name: "SalTaxRate");

            migrationBuilder.DropTable(
                name: "SalWelfareCalc");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "SourceStatistic");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "SysModule");

            migrationBuilder.DropTable(
                name: "TableIdentity");

            migrationBuilder.DropTable(
                name: "TaskJob");

            migrationBuilder.DropTable(
                name: "TaskSetting");

            migrationBuilder.DropTable(
                name: "TransferObjectList");

            migrationBuilder.DropTable(
                name: "UploadItem");

            migrationBuilder.DropTable(
                name: "UserTrace");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
