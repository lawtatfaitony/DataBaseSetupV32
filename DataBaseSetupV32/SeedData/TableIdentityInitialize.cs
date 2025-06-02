using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DataBaseSetupV3
{
    public static class TableIdentityInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();
         
        public static void TableIdentityInitializeSeedData()
        {
            #region  Initialize seed data TableIdentity  
            DateTime dt = DateTime.Now;
            var tableIdentitys = new List<TableIdentity>
            {
                 new TableIdentity{ TableName ="AspNetUsers" , TableIdentityId =int.Parse(DateTime.Now.ToString("MMdd")),OperatedDate =dt }
            };
            tableIdentitys.ForEach(a =>
            {
                if (context.TableIdentity.Find(a.TableName) == null)
                { 
                    context.TableIdentity.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2}", a.TableName, a.TableIdentityId, a.OperatedDate));
                }
                else
                {
                    Console.WriteLine(string.Format("Exists : {0} {1} {2} ", a.TableName, a.TableIdentityId, a.OperatedDate));
                }
                Thread.Sleep(300);
            });  
            context.SaveChanges();
            #endregion
        }
    } 
}
