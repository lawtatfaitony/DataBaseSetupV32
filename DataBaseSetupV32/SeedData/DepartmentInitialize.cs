using System;
using System.Collections.Generic; 
using System.Threading;
using DataBaseSetupV3.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DataBaseSetupV3
{
    public static class DepartmentInitialize
    {
       
        public static void DepartmentInitializeSeedData(string IndustryId)
        {
            var context = Configurations.GetDataBaseContext();

            #region  Initialize 
            string MainComId = SystemData.CreateMainComId();
                
            Department department = new Department {DepartmentId = string.Format("D1{0}",MainComId),DepartmentName = "DEPT1",EnDepartmentName = "d1", DepartmentAbbrName = "D1", MainComId = MainComId,CompanyName = MainComId,IndustryId = IndustryId};
                 
            if(context.Department.Find(department.DepartmentId)==null)
            {
                context.Department.Add(department);
            }
                 
            int result = context.SaveChanges();
            if(result > 0)
            {
                Console.WriteLine(string.Format("SUCCESS : {0}  result rows = {1} ", department.DepartmentId, result));
            }
            else{
                Console.WriteLine(string.Format("FAILURE : {0}  result rows = {1} ", department.DepartmentId, result));
            }
            #endregion
             
        }
    }
}
