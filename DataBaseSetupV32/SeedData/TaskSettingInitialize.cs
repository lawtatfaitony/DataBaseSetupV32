using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DataBaseSetupV3
{
    public static class TaskSettingInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static void TaskSettingInitializeSeedData()
        {
            #region  Initialize seed data TaskSettingId,CalcPeriodType,CalcPeriodSpan,TaskRuningStartTime,TaskRuningEndTime,TimesOfTaskRunning,TaskStartDate,TaskRemarks
            DateTime dt = DateTime.Now;
            var taskSettings = new List<TaskSetting>
            {
                 new TaskSetting{ TaskSettingId ="CalcPeriodType_DEFINITION" , CalcPeriodType =4, CalcPeriodSpan =60,TaskRuningStartTime=new TimeSpan(0,3,1,0,0),TaskRuningEndTime=new TimeSpan(0,3,20,0,0), TimesOfTaskRunning=0,TaskStartDate =dt.AddHours(2),TaskRemarks ="Definetion Exection" },
                 new TaskSetting{ TaskSettingId ="CalcPeriodType_MONTHLY_ScheduleCalc" , CalcPeriodType =2, CalcPeriodSpan =60,TaskRuningStartTime=new TimeSpan(0,3,1,0,0),TaskRuningEndTime=new TimeSpan(0,3,20,0,0), TimesOfTaskRunning=1,TaskStartDate = dt.AddHours(2),TaskRemarks ="System" },
                 new TaskSetting{ TaskSettingId ="CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob" , CalcPeriodType =0, CalcPeriodSpan =300,TaskRuningStartTime=new TimeSpan(0,1,1,0,0),TaskRuningEndTime=new TimeSpan(0,23,59,0,0), TimesOfTaskRunning=1,TaskStartDate = dt.AddHours(2),TaskRemarks ="System" },
                 new TaskSetting{ TaskSettingId ="TaskFactoryScheduleJOB" , CalcPeriodType =0, CalcPeriodSpan =0,TaskRuningStartTime=new TimeSpan(0,1,1,0,0),TaskRuningEndTime=new TimeSpan(0,23,59,0,0), TimesOfTaskRunning=1,TaskStartDate = dt.AddHours(2),TaskRemarks ="System" }
            };
            taskSettings.ForEach(a =>
            {
                if (context.TaskSetting.Find(a.TaskSettingId ) == null)
                { 
                    context.TaskSetting.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3} {4} {5}", a.TaskSettingId, a.TaskStartDate, a.CalcPeriodType, a.TaskStartDate, a.TaskRuningStartTime, a.TaskRuningStartTime));
                }
                else
                {
                    Console.WriteLine(string.Format("Exists : {0} {1} {2} {3} {4} {5}", a.TaskSettingId, a.TaskStartDate, a.CalcPeriodType, a.TaskStartDate, a.TaskRuningStartTime, a.TaskRuningStartTime));
                }
                Thread.Sleep(300);
            });  
            context.SaveChanges();
            #endregion
        }
    } 
}
