using LanguageResource;
using System;
using System.Collections.Generic;
using System.Threading;
using DataBaseSetupV3.SeedData;
using Microsoft.Extensions.DependencyInjection;
using AttendanceBussiness.DbFirst;
namespace DataBaseSetupV3
{
    public static class IndustryInitialize
    {  
        public static void IndustryInitializeSeedData()
        {
            var context = Configurations.GetDataBaseContext();

            #region  Initialize seed data
            var Industries = new List<Industry>
            {
				 new Industry{ IndustryId ="IN00001" , IndustryName = LangAuto.Auto("商用服務業"), EnIndustryName ="Business services",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00002" , IndustryName = LangAuto.Auto("飲食業"), EnIndustryName ="Catering",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00003" , IndustryName = LangAuto.Auto("通訊業"), EnIndustryName ="Communication industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00005" , IndustryName = LangAuto.Auto("住戶服務業"), EnIndustryName ="Residential Services",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00006" , IndustryName = LangAuto.Auto("教育服務業"), EnIndustryName ="Education service industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00007" , IndustryName = LangAuto.Auto("金融業"), EnIndustryName ="Financial industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00008" , IndustryName = LangAuto.Auto("政府部門"), EnIndustryName ="Government department",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00009" , IndustryName = LangAuto.Auto("醫院"), EnIndustryName ="Hospital",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00010" , IndustryName = LangAuto.Auto("酒店業"), EnIndustryName ="Hospitality Industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00011" , IndustryName = LangAuto.Auto("進出口貿易"), EnIndustryName ="Import and export trade",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00012" , IndustryName = LangAuto.Auto("保險業"), EnIndustryName ="Insurance",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00013" , IndustryName = LangAuto.Auto("電子製品業"), EnIndustryName ="Electronic product industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00014" , IndustryName = LangAuto.Auto("金屬製品業"), EnIndustryName ="Metal products industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00015" , IndustryName = LangAuto.Auto("塑膠製品業"), EnIndustryName ="Plastic products industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00016" , IndustryName = LangAuto.Auto("紡織業"), EnIndustryName ="Textile industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00017" , IndustryName = LangAuto.Auto("服裝製品業"), EnIndustryName ="Apparel Industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00018" , IndustryName = LangAuto.Auto("地產業"), EnIndustryName ="Real estate",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00019" , IndustryName = LangAuto.Auto("零售業"), EnIndustryName ="Retail",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00020" , IndustryName = LangAuto.Auto("倉庫業"), EnIndustryName ="Warehouse industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00021" , IndustryName = LangAuto.Auto("運輸業"), EnIndustryName ="Transportation",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00022" , IndustryName = LangAuto.Auto("福利機構"), EnIndustryName ="Welfare agency",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00023" , IndustryName = LangAuto.Auto("批發業"), EnIndustryName ="Wholesale industry",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00024" , IndustryName = LangAuto.Auto("其他社區及社會服務業"), EnIndustryName ="Other community and social services",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00025" , IndustryName = LangAuto.Auto("其他製造業"), EnIndustryName ="Other manufacturing",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN00026" , IndustryName = LangAuto.Auto("其他個人服務業"), EnIndustryName ="Other personal services",ParentsIndustryId=0 },
				 new Industry{ IndustryId ="IN60006" , IndustryName = LangAuto.Auto("建造業"), EnIndustryName ="Construction industry",ParentsIndustryId=0 }
            };

            Industries.ForEach(a =>
            {
                if (context.Industry.Find(a.IndustryId)==null)
                {
                    context.Industry.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.IndustryId, a.IndustryName, a.EnIndustryName, a.ParentsIndustryId));
                }
                else
                {
                    Console.WriteLine(string.Format("EXISTS : {0} {1} {2} {3}",a.IndustryId, a.IndustryName , a.EnIndustryName,a.ParentsIndustryId ));
                }
                Thread.Sleep(100);
            }); //Industries
            context.SaveChanges();
            #endregion
        }
    } 
}
