using EF_Core_04_Join_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_04_Join_Demo
{
    internal class CompanyDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = Mohamed-Hesham\\MSSQLSERVER01 ; Database = CompanyV2; Integrated Security = True; TrustServerCertificate = True");
         optionsBuilder.UseLazyLoadingProxies(true);//Should install package  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //usnig Fluent Api 
            modelBuilder.Entity<Empolyee>().OwnsOne(e => e.DetailedAddress);
        }
      public   DbSet<Department> Departments { get; set; }
      public   DbSet<Empolyee> Empolyes { get; set; }
    }
}
