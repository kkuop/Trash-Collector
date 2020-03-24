using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollectorWebApp.Models;

namespace TrashCollectorWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PickUp> PickUps { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "63f5608d-ee63-47bb-b28a-e19df3176a1e", ConcurrencyStamp = "019e9155-bef1-4fe2-ac03-ae6d642dc869", Name = "Customer", NormalizedName = "CUSTOMER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "ffa519d6-987c-4cf8-82b6-0c648a9d778a", ConcurrencyStamp = "9d56beee-fa4f-4cfe-9449-0ada54ce389a", Name = "Employee", NormalizedName = "EMPLOYEE" });
        }
    }
}
