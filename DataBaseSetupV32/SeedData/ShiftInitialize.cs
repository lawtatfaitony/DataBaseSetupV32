using System;
using DataBaseSetupV3.Model;
using System.Collections.Generic; 
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace DataBaseSetupV3
{
    public static class ShiftInitialize
    {
        private static DataBaseContext databaseContext = Configurations.GetDataBaseContext();
        public static void ShiftInitializeSeedData()
        {
             
            #region  Initialize 
            string MainComId = SystemData.CreateMainComId();

            //[FROM JSON]
            string shiftListJsonPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "JsonData");
            string shiftJsonFileName = "ShiftList.json";
            string shiftJsonPathFileName = Path.Combine(shiftListJsonPath, shiftJsonFileName);
            if (File.Exists(shiftJsonPathFileName))
            {
                string shiftJson = CommonBase.ReadDataFromJson(shiftJsonPathFileName);

                List<Shift> shiftList = new List<Shift>();

                shiftList = JsonConvert.DeserializeObject<List<Shift>>(shiftJson);

                foreach(Shift shift in shiftList)
                {
                    databaseContext.Shift.Add(shift);
                }
                int result = databaseContext.SaveChanges();
                if (result > 0)
                {
                    Console.WriteLine(string.Format("SUCCESS : {0}  result rows = {1} ", MainComId, result));
                }
                else
                {
                    Console.WriteLine(string.Format("FAILURE : {0}  result rows = {1} ", MainComId, result));
                }
            }
            else
            {
                Shift shift1 = new Shift
                {
                    ShiftId = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                    ShiftAbbrId = "AA",
                    IconColor = "#FC0366",
                    ShiftName = "朝玖晚伍GLOBAL",
                    ShiftBusinessMode = 0,
                    ShiftAppliedMode = 0,
                    DepartmentIdArr = "",
                    MainComId = MainComId,
                    CompanyName = MainComId,
                    WorkTimeSpan = 9,
                    WorkStart = new TimeSpan(9, 0, 0),
                    WorkEnd = new TimeSpan(18, 0, 0),
                    WorkStartAllowance = 15,
                    WorkEndAllowance = 15,
                    WorkStartBuffer = 120,
                    WorkEndBuffer = 120,
                    SpecialWeekDays = "6",
                    SpecialWeekDaysWorkStart = new TimeSpan(9, 0, 0),
                    SpecialWeekDaysWorkEnd = new TimeSpan(13, 0, 0),
                    ExcludeWeekDay = string.Empty,
                    ExcludeOverTime = string.Empty,
                    OverTimeSpan = 0,
                    OverTimeStart = new TimeSpan(0, 0, 0),
                    OverTimeEnd = new TimeSpan(0, 0, 0),
                    OverTimeStartBuffer = 0,
                    OverTimeEndBuffer = 0,
                    LunchTimeSpan = 1,
                    LunchTimeStart = new TimeSpan(13, 0, 0),
                    LunchTimeEnd = new TimeSpan(14, 0, 0),
                    LunchTimeStartBuffer = 30,
                    LunchTimeEndBuffer = 30,
                    BreakTimeSpan = 0,
                    BreakTimeCalcStart = new TimeSpan(0, 0, 0),
                    BreakTimeCalcEnd = new TimeSpan(0, 0, 0),
                    BreakTimeAllowance = 0,
                    IsAutoCalcMissing = true,
                    MissingWorkOn = 1,
                    MissingWorkOff = 1,
                    MissingLunchStart = 1,
                    MissingLunchEnd = 1,
                    MissingOverTimeStart = 1,
                    MissingOverTimeEnd = 1,
                    AppliedStartDate = DateTime.Now,
                    AppliedEndDate = DateTime.Now.AddYears(5),
                    RuleDescription = "",
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    OperatedUserName = "SYSTEM",
                    IsApproved = true
                };

                Shift shift2 = new Shift
                {
                    ShiftId = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now.AddMinutes(1)),
                    ShiftAbbrId = "BB",
                    IconColor = "#fc0366",
                    ShiftName = "晚9朝6(DEF)",
                    ShiftBusinessMode = 0,
                    ShiftAppliedMode = 1,
                    DepartmentIdArr = "",
                    MainComId = MainComId,
                    CompanyName = MainComId,
                    WorkTimeSpan = 9,
                    WorkStart = new TimeSpan(21, 0, 0),
                    WorkEnd = new TimeSpan(6, 0, 0),
                    WorkStartAllowance = 15,
                    WorkEndAllowance = 15,
                    WorkStartBuffer = 120,
                    WorkEndBuffer = 120,
                    SpecialWeekDays = "6",
                    SpecialWeekDaysWorkStart = new TimeSpan(21, 0, 0),
                    SpecialWeekDaysWorkEnd = new TimeSpan(1, 0, 0),
                    ExcludeWeekDay = string.Empty,
                    ExcludeOverTime = string.Empty,
                    OverTimeSpan = 0,
                    OverTimeStart = new TimeSpan(0, 0, 0),
                    OverTimeEnd = new TimeSpan(0, 0, 0),
                    OverTimeStartBuffer = 0,
                    OverTimeEndBuffer = 0,
                    LunchTimeSpan = 1,
                    LunchTimeStart = new TimeSpan(1, 0, 0),
                    LunchTimeEnd = new TimeSpan(2, 0, 0),
                    LunchTimeStartBuffer = 30,
                    LunchTimeEndBuffer = 30,
                    BreakTimeSpan = 0,
                    BreakTimeCalcStart = new TimeSpan(0, 0, 0),
                    BreakTimeCalcEnd = new TimeSpan(0, 0, 0),
                    BreakTimeAllowance = 0,
                    IsAutoCalcMissing = true,
                    MissingWorkOn = 1,
                    MissingWorkOff = 1,
                    MissingLunchStart = 1,
                    MissingLunchEnd = 1,
                    MissingOverTimeStart = 1,
                    MissingOverTimeEnd = 1,
                    AppliedStartDate = DateTime.Now,
                    AppliedEndDate = DateTime.Now.AddYears(5),
                    RuleDescription = "",
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    OperatedUserName = "SYSTEM",
                    IsApproved = true
                };

                if (databaseContext.Shift.Find(shift1.ShiftId) == null)
                {
                    databaseContext.Shift.Add(shift1);
                }
                if (databaseContext.Shift.Find(shift2.ShiftId) == null)
                {
                    databaseContext.Shift.Add(shift2);
                }
                 
                int result = databaseContext.SaveChanges();
                if (result > 0)
                {
                    Console.WriteLine(string.Format("SUCCESS : {0}  result rows = {1} ", MainComId, result));
                }
                else
                {
                    Console.WriteLine(string.Format("FAILURE : {0}  result rows = {1} ", MainComId, result));
                }
            }
            

            #endregion 
        }
    }
}
