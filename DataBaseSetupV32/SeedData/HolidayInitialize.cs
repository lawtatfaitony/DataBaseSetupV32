using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using DataBaseSetupV3.SeedData;
using AttendanceBussiness.DbFirst;
using System.Linq;

namespace DataBaseSetupV3
{
    class HolidayInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();

        /// <summary>
        /// 導入假期數據到數據庫中。    
        /// </summary>
        public static void HolidayKeyDataImport()
        {
            #region  Initialize  UserRoleSystemAdminAsigned 
            string mainComId = SystemData.CreateMainComId();
            string IndustryId = SystemData.GetIndustryId();

            //如果從政府公眾假期API獲取假期數據，則需要在此處添加相應的代碼來獲取和解析假期數據。   
            List<HolidayNameAndDate> listOfHolidayNameAndDate = PublicHoliday.GetListOfHoliday().Result;
            if(listOfHolidayNameAndDate == null || listOfHolidayNameAndDate.Count == 0)
            {
                var holidays = new List<Holiday>
                {
                    new Holiday{ HolidayId =  string.Format("Women{1:yyyyMMdd}{0}",mainComId,new DateTime(DateTime.Now.Year,3,8)) , HolidayCnName = LangAuto.Auto("婦女節"), HolidayEnName ="Women's Day", HolidayDate = new DateTime(DateTime.Now.Year,3,8), StatutoryHoliday = true,MainComId = mainComId},
                    new Holiday{ HolidayId =  string.Format("NowYear{1:yyyyMMdd}{0}",mainComId,new DateTime(DateTime.Now.Year+1,1,1)) , HolidayCnName = LangAuto.Auto("新年"), HolidayEnName ="New Year", HolidayDate = new DateTime(DateTime.Now.Year+1,1,1), StatutoryHoliday = true,MainComId = mainComId},
                    new Holiday{ HolidayId =  string.Format("Chistmas{1:yyyyMMdd}{0}",mainComId,new DateTime(DateTime.Now.Year,12,25)) , HolidayCnName = LangAuto.Auto("聖誕節"), HolidayEnName ="Christmas", HolidayDate = new DateTime(DateTime.Now.Year,12,25), StatutoryHoliday = true,MainComId = mainComId},
                    new Holiday{ HolidayId = string.Format("ChildenDay{1:yyyyMMdd}{0}",mainComId,new DateTime(DateTime.Now.Year,6,1)) , HolidayCnName = LangAuto.Auto("兒童節"), HolidayEnName ="Childen Day", HolidayDate = new DateTime(DateTime.Now.Year,6,1), StatutoryHoliday = true,MainComId = mainComId}
                };
                holidays.ForEach(a =>
                {
                    if (context.Holiday.ContainsAsync(a) == null)
                    {
                        context.Holiday.Add(a);
                        Console.WriteLine(string.Format("HOLIDAY SUCCESS : {0} {1} ", a.HolidayId, a.HolidayEnName));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("HOLIDAY EXISTS : {0} {1}", a.HolidayId, a.HolidayEnName));
                    }

                    context.Holiday.Add(a);

                    Thread.Sleep(100);
                });
                context.SaveChanges();
            }
            else
            { 
                listOfHolidayNameAndDate.ForEach(a =>
                {
                    Holiday holiday = new Holiday
                    {
                        HolidayId = string.Format("{0}{1:yyyyMMdd}", mainComId, a.HolidayDate),
                        HolidayCnName = a.HolidayCnName,
                        HolidayEnName = a.HolidayEnName,
                        HolidayDate = a.HolidayDate,
                        StatutoryHoliday = true,
                        HolidayPaidType = 1, // 假設為1(有薪假期=1)，根據實際情況調整
                        HolidayPaidTypeName = LangAuto.Auto("有薪假期"),
                        OnDutyPaidRatio = 1.0m, // 假設為1.0，根據實際情況調整
                        MainComId = mainComId
                    };

                    if (!context.Holiday.Any(c=>c.MainComId.Contains(holiday.MainComId) && c.HolidayDate.Date == holiday.HolidayDate.Date))
                    {
                        context.Holiday.Add(holiday);
                        Console.WriteLine(string.Format("HOLIDAY SUCCESS : {0} {1} ", holiday.HolidayId, a.HolidayEnName));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("HOLIDAY EXISTS : {0} {1}", holiday.HolidayId, a.HolidayEnName));
                    } 
                    context.Holiday.Add(holiday);

                    Thread.Sleep(100);
                });
                context.SaveChanges();
            }
            
            #endregion
        }
    }
}