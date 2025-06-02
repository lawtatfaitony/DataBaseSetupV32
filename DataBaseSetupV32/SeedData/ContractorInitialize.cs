using AttendanceBussiness.DbFirst;
using DataBaseSetupV3.SeedData;
using System;
using System.Collections.Generic;
using System.Threading; 
namespace DataBaseSetupV3
{
	public static class ContractorInitialize
	{
         
        public static void ContractorInitializeSeedData(string IndustryId)
        {
            var context = Configurations.GetDataBaseContext();

            #region  Initialize seed data
            string MainComId = SystemData.CreateMainComId();
            MainCom mainCom = context.MainCom.Find(MainComId);
            Industry industry = context.Industry.Find(IndustryId);
            if(industry == null)
            {
                industry = new Industry { IndustryId = "IN60006", IndustryName = LangAuto.Auto("Construction Industry"), EnIndustryName = "Construction Industry", ParentsIndustryId = 0 };
                
                IndustryInitialize.IndustryInitializeSeedData();
                
            }
            var contractors = new List<Contractor>
            {
                 new Contractor{ ContractorId =$"Con{MainComId}" , ContractorName =LangAuto.Auto(mainCom.CompanyName), MainComId=MainComId,CompanyName= LangAuto.Auto(mainCom.CompanyName),IndustryId=IndustryId,IndustryName= LangAuto.Auto(industry.IndustryName),ContactName = LangAuto.Auto(mainCom.CompanyName),ContactPhone="123456" ,CompanyTel="123456",CompanyFax="123456",CompanyNameLogo="",ServiceStartDate=DateTime.Now,ServiceEndDate=DateTime.Now,CompanyAddress=LangAuto.Auto(mainCom.CompanyAddress),OperatedUserName="SYSTEM",OperatedDate=DateTime.Now}
			};
            contractors.ForEach(a =>
            {
                if (context.Contractor.Find(a.ContractorId) ==null)
                {
                    context.Contractor.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.ContractorId, a.ContractorName, a.MainComId, a.IndustryId));
                }
                else
                {
                    Console.WriteLine(string.Format("EXISTS : {0} {1} {2} {3}", a.ContractorId, a.ContractorName, a.MainComId, a.IndustryId));
                }
                Thread.Sleep(200);
            }); 
            context.SaveChanges();
            #endregion
        }
    } 
}
