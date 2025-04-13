﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseSetupV3.DbFirst
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApproveFlow> ApproveFlow { get; set; }
        public virtual DbSet<ApproveFlowLog> ApproveFlowLog { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AttLog> AttLog { get; set; }
        public virtual DbSet<AttPolicy> AttPolicy { get; set; }
        public virtual DbSet<AttPolicyCalc> AttPolicyCalc { get; set; }
        public virtual DbSet<AttPolicyOfEply> AttPolicyOfEply { get; set; }
        public virtual DbSet<AttendanceByCom> AttendanceByCom { get; set; }
        public virtual DbSet<AttendanceByDay> AttendanceByDay { get; set; }
        public virtual DbSet<AttendanceByPeriod> AttendanceByPeriod { get; set; }
        public virtual DbSet<AttendanceByShift> AttendanceByShift { get; set; }
        public virtual DbSet<AttendanceLog> AttendanceLog { get; set; }
        public virtual DbSet<CardManage> CardManage { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<DefinitedPeriod> DefinitedPeriod { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceUser> DeviceUser { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EplyFinance> EplyFinance { get; set; }
        public virtual DbSet<EplyFinanceItem> EplyFinanceItem { get; set; }
        public virtual DbSet<EplyFinanceItemName> EplyFinanceItemName { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<InfoCate> InfoCate { get; set; }
        public virtual DbSet<InfoDetail> InfoDetail { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<LeaveTypeDay> LeaveTypeDay { get; set; }
        public virtual DbSet<MainCom> MainCom { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<SalAssessment> SalAssessment { get; set; }
        public virtual DbSet<SalTaxRate> SalTaxRate { get; set; }
        public virtual DbSet<SalWelfareCalc> SalWelfareCalc { get; set; }
        public virtual DbSet<SalaryAndFinanceSecurity> SalaryAndFinanceSecurity { get; set; }
        public virtual DbSet<SalaryDeduction> SalaryDeduction { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<SourceStatistic> SourceStatistic { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<SysModule> SysModule { get; set; }
        public virtual DbSet<TableIdentity> TableIdentity { get; set; }
        public virtual DbSet<TaskJob> TaskJob { get; set; }
        public virtual DbSet<TaskSetting> TaskSetting { get; set; }
        public virtual DbSet<TransferObjectList> TransferObjectList { get; set; }
        public virtual DbSet<UploadItem> UploadItem { get; set; }
        public virtual DbSet<UserTrace> UserTrace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.9;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApproveFlow>(entity =>
            {
                entity.Property(e => e.ApproveFlowId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalUserIds)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AprovedByDeptSupervisor).HasComment("如果只局限於部門審批,則不指定審批用戶ID,或者作為備審人員 來源 Department.UserId");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.StartupDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("多用戶審批流程---啟動日期[Startup Datetime]: 把之前單用戶審批分開處理的時間起點。");

                entity.Property(e => e.TableColumn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApproveFlowLog>(entity =>
            {
                entity.Property(e => e.ApproveFlowLogId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalUserName).HasMaxLength(50);

                entity.Property(e => e.ApproveFlowId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.PrimaryxKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).HasMaxLength(300);

                entity.Property(e => e.SourceRowHash)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TableColumn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetResult).HasComment("ApproveFlowLog.Status  判斷上一個節點 ApproveFlowLog.TargetResult是否和下一個節點的ApproveFlowLog.TargetResult 是否一致. ");

                entity.Property(e => e.UndoTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IndustryId).HasMaxLength(20);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AttLog>(entity =>
            {
                entity.HasKey(e => e.AttendanceLogId);

                entity.Property(e => e.AttendanceLogId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AccesscardId).HasMaxLength(200);

                entity.Property(e => e.CatchPicture).HasColumnType("text");

                entity.Property(e => e.CatchPictureFileName).HasMaxLength(256);

                entity.Property(e => e.CnName).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(128);

                entity.Property(e => e.CratedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.DeviceId).HasMaxLength(128);

                entity.Property(e => e.DeviceName).HasMaxLength(128);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FacialArea)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FacialAvatar).HasColumnType("text");

                entity.Property(e => e.HmacHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.JobName).HasMaxLength(128);

                entity.Property(e => e.LatitudeAndLongitude).HasMaxLength(500);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Mode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ObjData).HasMaxLength(500);

                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.PositionTitle).HasMaxLength(128);

                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(128);
            });

            modelBuilder.Entity<AttPolicy>(entity =>
            {
                entity.Property(e => e.AttPolicyId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AttPolicyLabelName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperatedUser).HasMaxLength(256);

                entity.Property(e => e.PolicyConfig).IsUnicode(false);

                entity.Property(e => e.RuleDescription).HasColumnType("ntext");

                entity.Property(e => e.SettlePeriodMode).HasDefaultValueSql("((3))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AttPolicyCalc>(entity =>
            {
                entity.Property(e => e.AttPolicyCalcId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasComment("改用 對應 常量ShiftBusiness.ApprovedMode 但column name 保留不變, 2025-3-1, 功能:審批 拒絕 取消等狀態");

                entity.Property(e => e.AccountingComplete)
                    .HasDefaultValueSql("((1))")
                    .HasComment("OPEN=1");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ApprovedStatus)
                    .HasDefaultValueSql("((1))")
                    .HasComment("GeneralStatus 改為 ApprovedStatus 常量值是 ShiftBusiness.ApprovedMode");

                entity.Property(e => e.CalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ComfirmeddBy).HasMaxLength(256);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DateTimeForRpt).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.DrorCr).HasColumnName("DRorCR");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PolicyConfigLog)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttPolicyOfEply>(entity =>
            {
                entity.Property(e => e.AttPolicyOfEplyId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AttPolicyId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AttPolicyLabelName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PolicyConfig)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SettlePeriodMode).HasDefaultValueSql("((3))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AttendanceByCom>(entity =>
            {
                entity.Property(e => e.AttendanceByComId).HasMaxLength(30);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SysCalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AttendanceByDay>(entity =>
            {
                entity.Property(e => e.AttendanceByDayId).HasMaxLength(30);

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DayShiftListJson).HasMaxLength(500);

                entity.Property(e => e.DayShiftNameList).HasMaxLength(500);

                entity.Property(e => e.DayTotalLunchTimeSpan).HasDefaultValueSql("('00:00:00.0000000')");

                entity.Property(e => e.DayTotalOverTimeSpan).HasDefaultValueSql("('00:00:00.0000000')");

                entity.Property(e => e.DayTotalWorkNetTimeSpan).HasDefaultValueSql("('00:00:00.0000000')");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayName).HasMaxLength(150);

                entity.Property(e => e.HolidayPaidType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.HolidayPaidTypeName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.HolidayWithPaidRatio)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.LeaveId).HasMaxLength(20);

                entity.Property(e => e.LeavePaidType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.LeavePaidTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveWithPaidRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OccurDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OnDutyPaidRatioAvg)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OnDutyWorkRatioAvg)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SysCalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AttendanceByPeriod>(entity =>
            {
                entity.Property(e => e.AttendanceByPeriodId).HasMaxLength(30);

                entity.Property(e => e.AccuAbsentDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuHolidays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuLeaveDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuWorkDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AvgAttWeightedRatio)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((1))")
                    .HasComment("加權平均考勤率：加權平均法計算出這個時期的平均加權考勤率");

                entity.Property(e => e.AvgOnDutyPaidRatio).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AvgOnDutyWorkRatio).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CalcPeriodType).HasDefaultValueSql("((2))");

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ObjectData).HasColumnType("ntext");

                entity.Property(e => e.OverAllCompletedRatio)
                    .HasColumnType("decimal(18, 4)")
                    .HasComment("總體完成率 是指實際確切的工作時間減去應工作的排班時間 如週期(月度)結束,合理情況是100%");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.PresetWorkTimeSpan).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ShiftNameStructure).HasColumnType("ntext");

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysCalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AttendanceByShift>(entity =>
            {
                entity.Property(e => e.AttendanceByShiftId).HasMaxLength(30);

                entity.Property(e => e.BreakTimeTotalSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HolidayPaidTypeName).HasMaxLength(150);

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.LeaveId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LeavePaidTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveTypeName).HasMaxLength(150);

                entity.Property(e => e.LunchTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.LunchTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LunchTimeStart).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MissingLunchEnd).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MissingLunchStart).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MissingOverTimeEnd).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MissingOverTimeStart).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MissingWorkOff).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MissingWorkOn).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ObjData).HasColumnType("ntext");

                entity.Property(e => e.OnDutyPaidRatio)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OnDutyWorkRatio)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OverTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.OverTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OverTimeStart).HasColumnType("datetime");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiftName).HasMaxLength(150);

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SysCalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkActualNetTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkEnd).HasColumnType("datetime");

                entity.Property(e => e.WorkStart).HasColumnType("datetime");

                entity.Property(e => e.WorkTimeSpan).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<AttendanceLog>(entity =>
            {
                entity.Property(e => e.AttendanceLogId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AccesscardId).HasMaxLength(200);

                entity.Property(e => e.CatchPicture).HasColumnType("text");

                entity.Property(e => e.CatchPictureFileName).HasMaxLength(256);

                entity.Property(e => e.CnName).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(128);

                entity.Property(e => e.CratedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.DeviceId).HasMaxLength(128);

                entity.Property(e => e.DeviceName).HasMaxLength(128);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FacialArea)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FacialAvatar).HasColumnType("text");

                entity.Property(e => e.HmacHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.JobName).HasMaxLength(128);

                entity.Property(e => e.LatitudeAndLongitude).HasMaxLength(500);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Mode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ObjData).HasMaxLength(500);

                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.PositionTitle).HasMaxLength(128);

                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(128);
            });

            modelBuilder.Entity<CardManage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CardNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MapToUserDeviceSerialNo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OccupiedByEmployeeId).HasMaxLength(128);

                entity.Property(e => e.OccupiedByEmployeeName).HasMaxLength(128);

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhysicalId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasComment("0 = not ; 2 = applicable ; 2 =  active inactive");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");

                entity.Property(e => e.UserIds).IsUnicode(false);
            });

            modelBuilder.Entity<DefinitedPeriod>(entity =>
            {
                entity.Property(e => e.DefinitedPeriodId).HasMaxLength(30);

                entity.Property(e => e.DefinitedPeriodName).HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OperatedUserName)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PeriodEndDate).HasColumnType("date");

                entity.Property(e => e.PeriodStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentAbbrName).HasMaxLength(256);

                entity.Property(e => e.DepartmentName).HasMaxLength(256);

                entity.Property(e => e.EnDepartmentName).HasMaxLength(256);

                entity.Property(e => e.IndustryId).HasMaxLength(256);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MainComId).HasMaxLength(256);

                entity.Property(e => e.ParantsDeptId).HasMaxLength(128);

                entity.Property(e => e.ParentsDeptName).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.UserIds).HasMaxLength(512);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceId).HasMaxLength(50);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceSerialNo).HasMaxLength(512);

                entity.Property(e => e.HangDownDevices)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("DEV  JSON LIST 設備載體平台的 下掛設備 utf-8 編碼文字");

                entity.Property(e => e.IsReverseHex)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedUser)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasComment("0 = not ; 2 = applicable ; 2 =  active inactive");

                entity.Property(e => e.SysModuleId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccessCardId).HasMaxLength(128);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceId).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.DevidceUserProfileId).HasMaxLength(256);

                entity.Property(e => e.DownDelStatus).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DownDelStatusDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DownInsertStatus).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DownInsertStatusDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DownUpdateStatus).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DownUpdateStatusDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FingerPrints)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.PassKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SynchronizedStatusRemarks)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserIconPositive).HasColumnType("text");

                entity.Property(e => e.UserIconSide).HasColumnType("text");

                entity.Property(e => e.UserIconTopView).HasColumnType("text");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasMaxLength(128);

                entity.Property(e => e.AccessCardId).HasMaxLength(128);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CnName).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FingerPrint).HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.IdNumber).HasMaxLength(128);

                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.JobName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(128);

                entity.Property(e => e.ParentUserId).HasMaxLength(128);

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.PositionTitle).HasMaxLength(128);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.SiteId).HasMaxLength(128);

                entity.Property(e => e.SiteName).HasMaxLength(128);

                entity.Property(e => e.The3rdPartyEmployeeId).HasMaxLength(128);

                entity.Property(e => e.UserIcon).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<EplyFinance>(entity =>
            {
                entity.HasIndex(e => e.EplyFinanceId)
                    .HasName("IX_EplyFinanceId")
                    .IsUnique();

                entity.Property(e => e.EplyFinanceId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountingStatus).HasComment("会计状态");

                entity.Property(e => e.BankBusiness).HasMaxLength(2000);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.EmployeeFunllName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsClosed).HasComment("settle  account");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransBankingId)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TransBankingName).HasMaxLength(256);

                entity.Property(e => e.TransferNo)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EplyFinanceItem>(entity =>
            {
                entity.Property(e => e.EplyFinanceItemId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountingCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("會計記賬代碼 Accounting Code");

                entity.Property(e => e.AccountingDocuments)
                    .HasMaxLength(600)
                    .HasDefaultValueSql("(N'上存會計文件保存 文件名分號隔開的數組字符串')");

                entity.Property(e => e.AccountingStatus).HasComment("会计状态");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DrorCr)
                    .HasColumnName("DRorCR")
                    .HasComment("借或者贷");

                entity.Property(e => e.EmployeeFunllName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EplyFinanceId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Item Name : BusFee  LunchFee");

                entity.Property(e => e.ItemNameId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasComment(" = EplyFinanceItemNameId");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OccuredDateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1200)
                    .HasComment("系統使用的 json數據結果");

                entity.Property(e => e.SubmitUser)
                    .HasMaxLength(256)
                    .HasComment("提交申請者(USER)");

                entity.Property(e => e.Summary).HasMaxLength(600);

                entity.Property(e => e.UpDatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EplyFinanceItemName>(entity =>
            {
                entity.Property(e => e.EplyFinanceItemNameId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountingCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("會計記賬代碼 Accounting Code");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.Property(e => e.EventLogId).HasMaxLength(128);

                entity.Property(e => e.EventDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MessageIfException).HasMaxLength(2000);

                entity.Property(e => e.OperateDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperateLogContent).HasColumnType("ntext");

                entity.Property(e => e.OperateUserName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(N'SYSTEM')");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.HolidayId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayCnName).HasMaxLength(150);

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayEnName).HasMaxLength(150);

                entity.Property(e => e.HolidayPaidTypeName).HasMaxLength(50);

                entity.Property(e => e.IsWholeDay).HasDefaultValueSql("((1))");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OnDutyPaidRatio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.IndustryId).HasMaxLength(128);
            });

            modelBuilder.Entity<InfoCate>(entity =>
            {
                entity.Property(e => e.InfoCateId)
                    .HasColumnName("InfoCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.InfoCateName).HasMaxLength(50);

                entity.Property(e => e.LanguageCode).HasMaxLength(20);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(128);

                entity.Property(e => e.PrarentsId)
                    .HasColumnName("PrarentsID")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<InfoDetail>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("PK_dbo.InfoDetail");

                entity.Property(e => e.InfoId).HasMaxLength(20);

                entity.Property(e => e.Author).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InfoCateId).HasMaxLength(6);

                entity.Property(e => e.InfoDescription).HasColumnType("ntext");

                entity.Property(e => e.InfoItemTemplateIds).HasMaxLength(256);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.SeoDescription).HasMaxLength(256);

                entity.Property(e => e.SeoKeyword).HasMaxLength(256);

                entity.Property(e => e.StaffId).HasMaxLength(128);

                entity.Property(e => e.SubTitle).HasMaxLength(512);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.TitleThumbNail).HasMaxLength(256);

                entity.Property(e => e.UserTraceId).HasMaxLength(128);

                entity.Property(e => e.VideoUrl).HasMaxLength(512);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((190605))");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.KeyName);

                entity.Property(e => e.KeyName).HasMaxLength(50);

                entity.Property(e => e.EnUs).HasColumnName("en_US");

                entity.Property(e => e.ZhCn).HasColumnName("zh_CN");

                entity.Property(e => e.ZhHk).HasColumnName("zh_HK");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.LeaveId).HasMaxLength(20);

                entity.Property(e => e.ApplovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("審批的日期時間");

                entity.Property(e => e.ApprovedRemarks).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.LeaveEndDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveStartDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OperatedUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(300);

                entity.Property(e => e.ScheduleId)
                    .IsUnicode(false)
                    .HasComment("allow the array or  Single");
            });

            modelBuilder.Entity<LeaveTypeDay>(entity =>
            {
                entity.HasKey(e => new { e.LeaveType, e.MainComId });

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(50)
                    .HasComment("MainComId 和 LeaveType 确定唯一的记录，例如定义 公司6000014的年假10天");

                entity.Property(e => e.MainComId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsForTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否允許與其他累計 如果統計總的請假天數則視乎此值");

                entity.Property(e => e.LeaveTypeDayId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Auto-increment ID 使用 函数 DataBaseContext.GetTableIdentityID");

                entity.Property(e => e.LeaveTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaxLeaveDaySpan)
                    .IsRequired()
                    .HasComment("累計的時長：年假10天，標準工作時間8小時，則對應的值等於80小時 ")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.MaxLeaveNatureWorkDay)
                    .HasColumnType("decimal(4, 2)")
                    .HasComment("如 3-8婦女節 半天假期 = 0.5 個工作日 換算成 MaxLeaveDaySpan =  0.5*GlobalConfig.StandardWorkDaySpan(8小時) 即4小時 ");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MainCom>(entity =>
            {
                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.CicReferenceNo).HasColumnName("CIC_ReferenceNo");

                entity.Property(e => e.CurrencySymbol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 7)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 7)");

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.MenuItemId).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParentsNodeId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("((0))")
                    .HasComment("default value = 0 (IsParentsNode)");
            });

            modelBuilder.Entity<SalAssessment>(entity =>
            {
                entity.Property(e => e.SalAssessmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedBy)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.EmployeeFunllName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FormulaOfAssessment)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OperatedUser)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SalaryAssessmentValue).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalTaxRate>(entity =>
            {
                entity.Property(e => e.SalTaxRateId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FullName).HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Quota)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("priority to use Ratio , if Ratio is zero then use the Quota.");

                entity.Property(e => e.Ratio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SettlePeriodMode).HasDefaultValueSql("((3))");

                entity.Property(e => e.SocialInsuranceRatio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalWelfareCalc>(entity =>
            {
                entity.Property(e => e.SalWelfareCalcId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ApprovedBy).HasMaxLength(256);

                entity.Property(e => e.ApprovedStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.CalcBusinessDesc).IsRequired();

                entity.Property(e => e.DrorCr).HasColumnName("DRorCR");

                entity.Property(e => e.EmployeeFunllName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EplyFinanceItemNameId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SalaryAndFinanceSecurity>(entity =>
            {
                entity.Property(e => e.SalaryAndFinanceSecurityId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.HamcResult)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.TargetPrimaryKey)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TargetTableName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SalaryDeduction>(entity =>
            {
                entity.Property(e => e.SalaryDeductionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountingComplete)
                    .HasDefaultValueSql("((1))")
                    .HasComment("OPEN=1");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ApprovedBy).HasMaxLength(256);

                entity.Property(e => e.AttendanceByPeriodId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.AvgOnDutyPaidRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AvgOnDutyWorkRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.DrorCr).HasColumnName("DRorCR");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.GeneralStatus)
                    .HasDefaultValueSql("((1))")
                    .HasComment("GeneralStatus (ACTIVE=1;INACTIVE = 0) ");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OverAllCompletedRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalaryAssessmentValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IdOfMonthlyShiftEmploy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SysCalcDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftId)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("((6))");

                entity.Property(e => e.AppliedEndDate).HasColumnType("date");

                entity.Property(e => e.AppliedStartDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentIdArr).HasMaxLength(500);

                entity.Property(e => e.ExcludeOverTime).HasMaxLength(50);

                entity.Property(e => e.ExcludeWeekDay).HasMaxLength(50);

                entity.Property(e => e.IconColor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FC0366')");

                entity.Property(e => e.LunchTimeEndBuffer).HasDefaultValueSql("((30))");

                entity.Property(e => e.LunchTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LunchTimeStartBuffer).HasDefaultValueSql("((30))");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MissingOverTimeEnd).HasDefaultValueSql("((1))");

                entity.Property(e => e.MissingOverTimeStart).HasDefaultValueSql("((1))");

                entity.Property(e => e.OperatedUserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.OverTimeEndBuffer).HasDefaultValueSql("((60))");

                entity.Property(e => e.OverTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OverTimeStartBuffer).HasDefaultValueSql("((60))");

                entity.Property(e => e.RuleDescription).HasMaxLength(600);

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SpecialWeekDays).HasMaxLength(50);

                entity.Property(e => e.SpecialWeekDaysWorkEnd).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkTimeSpan).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SiteAddress).HasMaxLength(256);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SourceStatistic>(entity =>
            {
                entity.HasKey(e => e.SourceStatisticsId)
                    .HasName("PK_dbo.SourceStatistic");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(128);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LoadTime).HasColumnName("loadTime");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OpenId).HasMaxLength(256);

                entity.Property(e => e.Osversion)
                    .HasColumnName("OSVersion")
                    .HasMaxLength(128);

                entity.Property(e => e.RecommUserId).HasMaxLength(128);

                entity.Property(e => e.SourceArea).HasMaxLength(256);

                entity.Property(e => e.TableKeyId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.VisitorIcon).HasMaxLength(256);

                entity.Property(e => e.WxNickName).HasMaxLength(50);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasMaxLength(128);

                entity.Property(e => e.ChannelId)
                    .HasColumnName("ChannelID")
                    .HasMaxLength(256);

                entity.Property(e => e.ContactTitle).HasMaxLength(100);

                entity.Property(e => e.IconPortrait).HasMaxLength(256);

                entity.Property(e => e.Introduction).HasColumnType("ntext");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.OtherChannelName).HasMaxLength(256);

                entity.Property(e => e.OtherQrcode).HasMaxLength(256);

                entity.Property(e => e.PublicNo).HasMaxLength(300);

                entity.Property(e => e.Qrcode).HasMaxLength(256);

                entity.Property(e => e.StaffName).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.UserName).HasMaxLength(128);
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasKey(e => e.KeyId);

                entity.Property(e => e.KeyId).HasMaxLength(128);

                entity.Property(e => e.Config)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FuncDesc).HasMaxLength(1200);

                entity.Property(e => e.GeneralStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SysModuleId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysModuleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TableIdentity>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK_dbo.TableIdentity");

                entity.Property(e => e.TableName).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaskJob>(entity =>
            {
                entity.Property(e => e.TaskJobId).HasMaxLength(20);

                entity.Property(e => e.CompletedDatetime).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetTalbeKeyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TriggerDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaskSetting>(entity =>
            {
                entity.Property(e => e.TaskSettingId).HasMaxLength(50);

                entity.Property(e => e.CalcPeriodSpan).HasDefaultValueSql("((60))");

                entity.Property(e => e.TaskRemarks).HasMaxLength(250);

                entity.Property(e => e.TaskRuningEndTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskRuningStartTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransferObjectList>(entity =>
            {
                entity.Property(e => e.TransferObjectListId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolderId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.HolderName).HasMaxLength(128);

                entity.Property(e => e.HolderRfId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ObjectId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ObjectName).HasMaxLength(128);

                entity.Property(e => e.ObjectRfId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("对应AccessCardId");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UploadItem>(entity =>
            {
                entity.Property(e => e.UploadItemId).HasMaxLength(100);

                entity.Property(e => e.FileExt).HasMaxLength(20);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.RawName).HasMaxLength(100);

                entity.Property(e => e.SubPath).HasMaxLength(256);

                entity.Property(e => e.TargetTalbeKeyId).HasMaxLength(256);

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<UserTrace>(entity =>
            {
                entity.Property(e => e.UserTraceId)
                    .HasColumnName("UserTraceID")
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.TableKeyId)
                    .HasColumnName("TableKeyID")
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
