using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataBaseSetupV3.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataBaseSetupV3.Data
{
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
                 
                //optionsBuilder.UseSqlServer("Data Source=TOPSERVER\\DATAGUARD;Initial Catalog=DataGuardXCore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;");
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }
    }
    
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(20)] 
        public string MainComId { get; set; }

        [MaxLength(20)] 
        public string IndustryId { get; set; }
    }
    public class ApplicationRole : IdentityRole
    { 
    }

    public class SystemUser: ISystemUser
    { 
        public string UserName { get; set; } 
        public string Email { get; set; } 
    }

    public interface ISystemUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
