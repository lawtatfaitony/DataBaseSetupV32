using DataBaseSetupV3;
using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Threading;
using DataBaseSetupV3.Context;

namespace DataBaseSetupV3
{
    public static class MainComInitialize
    { 
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static void MainComInitializeSeedData(string LanguageCode,string IndustryId,out string MainComId)
        {
            MainComId = SystemData.CreateMainComId();
            string companyName = AppSetting.GetConfig("CompanyName");

            Industry industry = context.Industry.Find(IndustryId); 
            if(industry!=null)
            {
                #region  Initialize seed data  MainCom
               
                List<MainCom> mainComs = new List<MainCom>
                {
                     new  MainCom{
                        MainComId = MainComId ,
                        CompanyName = companyName,
                        CompanyAbbreviation =$"M{MainComId}",
                        IndustryId = IndustryId,
                        IndustryName = industry.IndustryName??string.Empty,
                        ContactName =" ",
                        ContactPhone = "",
                        CompanyTel ="",
                        CompanyFax =  "",
                        CompanyLogo = "/Images/MainComDefaultLogo.jpg", //default logo
                        ReferenceNo = "",
                        ContractorNo = "",
                        ServiceStartDate= DateTime.Now,
                        ServiceEndDate= DateTime.Now,
                        Longitude =0,
                        Latitude =0,
                        CompanyAddress ="",
                        OperatedUserName="System",
                        OperatedDate= DateTime.Now,
                        ServiceStatus = 0,
                        CurrencySymbol = LanguageCode.Replace("-","").ToUpper()
                     }
                };
                mainComs.ForEach(a =>
                {
                    if (context.MainCom.Find(a.MainComId) == null)
                    {
                        context.MainCom.Add(a);
                        Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} ", a.MainComId, a.CompanyName, a.ContactName));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("EXIST : {0} {1} {2} ", a.MainComId, a.CompanyName, a.ContactName));
                    } 
                });
                context.SaveChanges();
                #endregion
            } 
        }
    }
}
