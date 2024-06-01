using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace EmployeeManagement.DataAccess
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConString = "";
            try
            {
                var configuration = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true)
             .Build();
                ConString = configuration.GetConnectionString("DefaultConnectionString")!;

                optionsBuilder.UseSqlServer(ConString);

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
      
    }

}