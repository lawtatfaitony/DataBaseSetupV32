using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AttDataCore.Context;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace AttendanceBussiness.DbFirst
{
    public partial class DataBaseContext : DbContext
    {
        /// <summary>
        /// 參數 "AF", "ApproveFlow",4 Result = AF2000
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tableName"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public string GetTableIdentityID(string prefix, string tableName, int lenght)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                if(dataBaseContext.Database.CanConnect())
                {
                    TableIdentity T = dataBaseContext.TableIdentity.Find(tableName); 
                     
                    if (T == null)
                    {
                        TableIdentity tableIdentity = new TableIdentity { TableIdentityId = 2000, TableName = tableName, OperatedDate = DateTime.Now };
                        dataBaseContext.TableIdentity.Add(tableIdentity);
                        bool retsult = dataBaseContext.SaveChanges() > 0;
                        if(retsult)
                        {
                            T = tableIdentity;
                        }
                    }
                    else
                    { 
                        T.TableIdentityId += 1;
                        T.OperatedDate = DateTime.Now; 
                        dataBaseContext.Update(T);
                        dataBaseContext.SaveChanges();
                    }
                    string NewID = prefix + T.TableIdentityId.ToString().PadLeft(lenght, '0');
                    return NewID;
                }
                else
                {
                    return DateTime.Now.ToLongTimeString();
                }
            } 
        }
        public string GetOffSetSecond(string prefix,int days)
        {

            DateTime dt1 = DateTime.Now;
            DateTime dt2 =dt1.AddDays(-days);

            DateTimeOffset dateTimeOffset1 = new DateTimeOffset(dt1);
            DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dt2);

            long GetOffSetSecond =Math.Abs(dateTimeOffset1.ToUnixTimeSeconds() - dateTimeOffset2.ToUnixTimeSeconds());

            string result = string.Format("{0}{1}", prefix, GetOffSetSecond);

            return result;
        }
        public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId)
        {
            string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
            string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
            string tohash = strStartDate + strEndDate; 
            string a = RemoveNumber(SHA1encode(tohash)).Substring(0, 3).ToUpper();
            string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

            return NewID;
        }
        public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId, string ShiftAbbrId)
        {
            string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
            string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
            //string a = RemoveNumber(SHA1encode(strStartDate + ShiftAbbrId + strEndDate)).Substring(0, 3).ToUpper(); //need to test
            string a = RemoveNumber(Guid.NewGuid().ToString("N")).Substring(0, 3).ToUpper();
            string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

            return NewID;
        }
        
        public static string RemoveNumber(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }
        
        public string SHA1encode(string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            using SHA1 hash = SHA1.Create();
            if (hash == null) throw new InvalidOperationException("[FUNC::DataBaseContext.SHA1encode] SHA1 not available.");
            byte[] hashBytes = hash.ComputeHash(bytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }
    }
}
