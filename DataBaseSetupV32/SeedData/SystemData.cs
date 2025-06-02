using System;
using System.Globalization;
namespace DataBaseSetupV3
{
    public class SystemData
    { 
        public static string CreateMainComId()
        {
            string MainComId;
            if (DataBaseSetupV3.MemoryCacheHelper.Contains("MainComId"))
            {
                MainComId = DataBaseSetupV3.MemoryCacheHelper.GetCacheItem<string>("MainComId");
                if(!string.IsNullOrEmpty(MainComId))
                {
                    return MainComId;
                }
            }
            
            MainComId = DateTime.Now.ToString("yyyyMMddHH");
            MainComId = MainComId.Remove(0, 2);
            return MainComId;
        }
        public static string GetIndustryId()
        {
            string IndustryId = string.Empty;
            if (DataBaseSetupV3.MemoryCacheHelper.Contains("IndustryId"))
            {
                IndustryId = DataBaseSetupV3.MemoryCacheHelper.GetCacheItem<string>("IndustryId");
                if (!string.IsNullOrEmpty(IndustryId))
                {
                    return IndustryId;
                }
            }
            
            return IndustryId;
        }
        public static string CreateSupervisorId()
        {
            string MainComId = CreateMainComId();
            string Generate_UserId = MainComId;
            return Generate_UserId;
        }
        public static string CreatePasswordHash()
        {
            string PasswordHash = "AQAAAAEAACcQAAAAEM70J4/m6gzta/Dv/2EADg6rIDuh8WsAZCRgR3wSEndIqCQqIcfje0eeUJFB1mbTKw=="; //admin888
            return PasswordHash;
        }
        public static string CreateSecurityStamp()
        {
            string SecurityStamp = "VNJLIKVYPQ6SR5UVSOQLD5W7235MLLKU";
            return SecurityStamp;
        }
        public static string CreateConcurrencyStamp()
        {
            string ConcurrencyStamp = "22907ff1-0b44-4532-93c2-351627c13b55";
            return ConcurrencyStamp;
        }

        public static void CheckParmsCache()
        {
            string MainComId;
            string IndustryId;
            if (DataBaseSetupV3.MemoryCacheHelper.Contains("MainComId"))
            {
                MainComId = DataBaseSetupV3.MemoryCacheHelper.GetCacheItem<string>("MainComId");
                if (!string.IsNullOrEmpty(MainComId))
                {
                    Console.WriteLine(">>> [CACHE] [MainComId] = {0}", MainComId);
                }
            }else
            {
                Console.WriteLine(">>> [NO CACHE] [MainComId] ");
            }
             
            if (DataBaseSetupV3.MemoryCacheHelper.Contains("IndustryId"))
            {
                IndustryId = DataBaseSetupV3.MemoryCacheHelper.GetCacheItem<string>("IndustryId");
                if (!string.IsNullOrEmpty(IndustryId))
                {
                    Console.WriteLine(">>> [CACHE] [IndustryId] = {0}", IndustryId);
                }
            }
            else
            {
                Console.WriteLine(">>> [NO CACHE] [IndustryId] ");
            }
        }

        /// <summary>
        /// 設置公司ID和行業ID的緩存
        /// </summary>
        /// <param name="args">默認行業ID = IN60006</param>
        /// <param name="offset"></param>
        public static void SetParmsCache(string[] args)
        {
            DateTime dt = DateTime.Now.AddHours(3);
            DateTimeOffset offset = new DateTimeOffset(dt);

            string MainComId;
            string IndustryId;

            if(args.Length == 0)
            {
                MainComId = CreateMainComId();  // DateTime.Now.ToString("yyyyMMddHH").Remove(0, 2);
                
                args = new string[] { MainComId, "IN60006" };
            }
            
            MainComId = args[0].Trim().ToUpper();
            DataBaseSetupV3.MemoryCacheHelper.Set("MainComId", MainComId, offset);
            Console.WriteLine(">>> [SET CACHE] [MainComId] = {0} [{1}]", MainComId, offset);

            if (args.Length > 1)
            {
                IndustryId = args[1].Trim().ToUpper();
                SetIndustryIdCache(IndustryId);  
            }
        }
         
        /// <summary>
        /// 設置公司ID和行業ID的緩存
        /// </summary>
        /// <param name="args">默認行業ID = IN60006</param>
        /// <param name="offset"></param>
        public static void SetIndustryIdCache(string IndustryId)
        {
            if(string.IsNullOrEmpty(IndustryId))
            {
                IndustryId = "IN60006"; // 默認行業ID
            }

            DateTime dt = DateTime.Now.AddHours(3);
            DateTimeOffset offset = new DateTimeOffset(dt);
             
            DataBaseSetupV3.MemoryCacheHelper.Set("IndustryId", IndustryId, offset);
            Console.WriteLine(">>> [SET CACHE] [IndustryId] = [{0} [{1}]]", IndustryId, offset);
        }
    }
}
