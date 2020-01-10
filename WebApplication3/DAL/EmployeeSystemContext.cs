using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication3.Models;

namespace WebApplication3.DAL
{
    public class EmployeeSystemContext : DbContext
        {
            public DbSet<Employee> Employee { get; set; }
            public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    }