using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading; 
using Newtonsoft.Json;
using AttendanceBussiness.DbFirst;
using Site = AttendanceBussiness.DbFirst.Site;

namespace DataBaseSetupV3
{
    public static class SiteInitialize
    {
        public static void SiteInitializeSeedData()
        {
             var databaseContext = Configurations.GetDataBaseContext();
            #region  Initialize 
            string MainComId = SystemData.CreateMainComId();
            string siteId = GetFirstSiteId();

            Site site = new Site { SiteId = siteId, SiteName = "Main Company Headquarters", MainComId = MainComId, SiteAddress = "Success Road No. 01"};
             
            if (databaseContext.Site.Find(site.SiteId) == null)
            {
                databaseContext.Site.Add(site);
            }
            int result =  databaseContext.SaveChanges();
            if(result > 0)
            {
                Console.WriteLine(string.Format("SUCCESS : {0}  result rows = {1} ", MainComId, result));
            }
            else{
                Console.WriteLine(string.Format("FAILURE : {0}  result rows = {1} ", MainComId, result));
            }

            #endregion
             
        }
        /// <summary>
        /// 獲取第一個SITE ID (DETAULT VAL)
        /// </summary>
        /// <returns></returns>
        public static string GetFirstSiteId()
        {
            string MainComId = SystemData.CreateMainComId();
            string siteId = string.Format("S{0}", MainComId);
            if (siteId.Length > 10)
                siteId = siteId.Substring(0, 10);

            return siteId;
        }

        /// <summary>
        /// 獲取默認的Site
        /// </summary>
        /// <returns></returns>
        public static Site GetDetauleSite()
        {
            var databaseContext = Configurations.GetDataBaseContext();
            Site site = databaseContext.Site.FirstOrDefault();

            if(site == null)
            {
                string MainComId = SystemData.CreateMainComId();
                string siteId = GetFirstSiteId();
                site = new Site { SiteId = siteId, SiteName = "Default Site Name1", MainComId = MainComId, SiteAddress = "Success Road No. 01" };
            }

            return site;
        }
    }
}
