using DataBaseSetupV3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using DataBaseSetupV3.SeedData;

namespace DataBaseSetupV3
{
    class HolidayInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static void HolidayKeyDataImport()
        {
            #region  Initialize  UserRoleSystemAdminAsigned 
            string mainComId = SystemData.CreateMainComId();
            string IndustryId = SystemData.GetIndustryId();

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
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} ", a.HolidayId,a.HolidayCnName));
                }
                else
                {
                    Console.WriteLine(string.Format("EXISTS : {0} {1}", a.HolidayId, a.HolidayCnName));
                }

                context.Holiday.Add(a);

                Thread.Sleep(100);
            });
            context.SaveChanges();
            #endregion
        }
    }
}