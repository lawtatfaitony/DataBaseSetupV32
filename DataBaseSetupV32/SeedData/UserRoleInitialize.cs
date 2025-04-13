using DataBaseSetupV3.Model;
using DataBaseSetupV3.SeedData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DataBaseSetupV3
{
    public class RoleConst {
        public const string SYSTEM_ADMIN = "SystemAdmin";
        public const string SYSTEM_OPERATOR = "SystemOperator";
        public const string ADMIN = "Admin";
        public const string MAINCOM_OPERATOR = "MainComOperator";
        public const string THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN = "ThirdPartyserviceContractorAdmin";
        public const string THIRDPARTY_SERVICE_CONTRACT_OROPERATOR = "ThirdPartyserviceContractorOperator";
        public const string EMPLOYEE = "Employee";
        public const string LRO = "LRO";
        public const string GUEST = "Guest";
        public const string DEPARTMENT = "Department";
        public const string ACCOUNTANT = "Accountant";
        public const string CASHIER = "Cashier";
        

    }
    public static class UserRoleInitialize
    {
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static void RoleSystemCreated()
        {
            var aspNetRoles = new List<AspNetRoles>
            {
                new AspNetRoles{ Id = RoleConst.SYSTEM_ADMIN.ToUpper() , Name = RoleConst.SYSTEM_ADMIN,NormalizedName = RoleConst.SYSTEM_ADMIN.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()  },
                new AspNetRoles{ Id = RoleConst.SYSTEM_OPERATOR.ToUpper() , Name = RoleConst.SYSTEM_OPERATOR,NormalizedName = RoleConst.SYSTEM_OPERATOR.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()  },
                new AspNetRoles{ Id = RoleConst.ADMIN.ToUpper() , Name = RoleConst.ADMIN,NormalizedName = RoleConst.ADMIN.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.MAINCOM_OPERATOR.ToUpper() , Name = RoleConst.MAINCOM_OPERATOR,NormalizedName = RoleConst.MAINCOM_OPERATOR.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN.ToUpper()  , Name =RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN ,NormalizedName =RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR.ToUpper() , Name = RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR,NormalizedName =RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.EMPLOYEE.ToUpper() , Name = RoleConst.EMPLOYEE,NormalizedName =RoleConst.EMPLOYEE.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.LRO.ToUpper() , Name = RoleConst.LRO, NormalizedName = RoleConst.LRO.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.GUEST.ToUpper() , Name = RoleConst.GUEST,NormalizedName = RoleConst.GUEST.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.DEPARTMENT.ToUpper() , Name = RoleConst.DEPARTMENT,NormalizedName = RoleConst.DEPARTMENT.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},

                new AspNetRoles{ Id = RoleConst.ACCOUNTANT.ToUpper() , Name = RoleConst.ACCOUNTANT,NormalizedName = RoleConst.ACCOUNTANT.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()},
                new AspNetRoles{ Id = RoleConst.CASHIER.ToUpper() , Name = RoleConst.CASHIER,NormalizedName = RoleConst.CASHIER.ToUpper(), ConcurrencyStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()}

            };
            aspNetRoles.ForEach(a =>
            {
                if (context.AspNetRoles.Find(a.Id) == null)
                {
                    context.AspNetRoles.Add(a);
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.Id, a.Name,a.NormalizedName,a.ConcurrencyStamp));
                }
                else
                {
                    Console.WriteLine(string.Format("SUCCESS : {0} {1} {2} {3}", a.Id, a.Name, a.NormalizedName, a.ConcurrencyStamp));
                }
                Thread.Sleep(1000);
            });  
            context.SaveChanges();
        }
        public static void UserRoleSystemAdminAsigned(string userId)
        {
            #region  Initialize  UserRoleSystemAdminAsigned

            string Generate_UserId = userId;// SystemData.CreateSupervisorId();  

             var aspNetUserRoles = new List<AspNetUserRoles>
                {
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.SYSTEM_ADMIN.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.SYSTEM_OPERATOR.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.ADMIN.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.EMPLOYEE.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.GUEST.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.LRO.ToUpper()},
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.MAINCOM_OPERATOR.ToUpper() },
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.THIRD_PARTY_SERVICE_CONTRACTOR_ADMIN.ToUpper() },
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.THIRDPARTY_SERVICE_CONTRACT_OROPERATOR.ToUpper() },
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.DEPARTMENT.ToUpper() },

                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.ACCOUNTANT.ToUpper() },
                        new AspNetUserRoles{ UserId = Generate_UserId , RoleId = RoleConst.CASHIER.ToUpper() }
                };

            do
            {
               aspNetUserRoles.ForEach(a =>
                    {
                        bool exist = context.AspNetUserRoles.Where(c => c.RoleId.Contains(a.RoleId) && c.UserId.Contains(a.UserId)).Count() == 0;
                        if (exist)
                        {
                            try
                            {
                                context.AspNetUserRoles.Add(a);
                                int result = context.SaveChanges();
                                if (result > 0)
                                {
                                    Console.WriteLine(string.Format("SUCCESS : {0} {1} ", a.UserId, a.RoleId));
                                }
                                else
                                {
                                    Console.WriteLine(string.Format("SaveChanges FAIL : {0} {1}   FAIL Result = {2}", a.UserId, a.RoleId, result));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(string.Format("Exception : {0}  ", e.Message));
                                var jsonA = JsonConvert.SerializeObject(a, Formatting.Indented);
                                Console.WriteLine(string.Format("\n{0}  ", jsonA));
                            }
                        }
                        else
                        {
                            Console.WriteLine(string.Format("EXISTS : {0} {1}", a.UserId, a.RoleId));
                        }
                        Thread.Sleep(300);
                    });
                Console.WriteLine("\nPRESS ENTER TO COMTINUE\n");
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            
            #endregion
        }
    } 
}
