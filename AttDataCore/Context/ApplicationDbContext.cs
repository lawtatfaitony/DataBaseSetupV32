using System;
using System.Collections.Generic;
using System.Text;
using AttDataCore.Context;
using AttendanceBussiness.DbFirst;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace AttendanceBussiness.DbFirst
{
    //ref::https://www.e-learn.cn/topic/3924774  
    /// <summary>
    /// 注入資料庫上下文法之 IdentityDbContext
    /// 使用者與角色 需要使用這個才能做UserManager,SigninManager 物件
    /// 2025-5-5
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if (!optionsBuilder.IsConfigured)
            {
                string CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
                //optionsBuilder.UseSqlServer("Data Source=SERVER1\\DATAGUARDSRV;Initial Catalog=DataGuardXcore;User ID=admin;Password=13711222146@mcessol;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;");
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }
    } 
     
}
