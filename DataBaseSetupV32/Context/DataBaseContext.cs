using System;
using DataBaseSetupV3.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataBaseSetupV3.Model
{
    /// <summary>
    /// row : MigrationId	ProductVersion  20240914153742_InitializeDatabase	3.1.9
    /// </summary>
    public partial class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //    optionsBuilder.UseSqlServer("Data Source=(local)\\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

                string CONNECTION_STRING = AppSetting.GetConfig("ConnectionStrings:DefaultConnection");
                //optionsBuilder.UseSqlServer("Data Source=192.168.0.9;Initial Catalog=DataGuardXCore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;");
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }
    }
}
