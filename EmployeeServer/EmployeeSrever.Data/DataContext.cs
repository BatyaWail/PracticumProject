using EmployeeServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        //DbContextOptionsBuilder
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employee-Db8");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
        //}
        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });

            //// Seed Users
            //modelBuilder.Entity<Company>().HasData(
            //    new Company { Id = 1, Name = "company1", Password = "123456" },
            //    new Company { Id = 2, Name = "company2", Password = "123456" },
            //    new Company { Id = 3, Name = "company3", Password = "123456" }

            //);

            // Seed Employees
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { Id = 1, Identity = "123456789", FirstName = "John", LastName = "Doe", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 1, 1), MaleOrFmale = true, Status = true , CompanyId=1},
            //    new Employee { Id = 2, Identity = "987654321", FirstName = "Jane", LastName = "Smith", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 5, 5), MaleOrFmale = false, Status = true, CompanyId=2 },
            //    new Employee { Id = 3, Identity = "456789123", FirstName = "Alice", LastName = "Johnson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 10, 10), MaleOrFmale = true, Status = false ,CompanyId=1}
            //);

            // Seed Roles
            //modelBuilder.Entity<Role>().HasData(
            //    new Role { Id = 1, RoleName = "Manager" },
            //    new Role { Id = 2, RoleName = "Developer" },
            //    new Role { Id = 3, RoleName = "Designer" }
            //);

            //Seed EmployeeRoles(Associations between Employees and Roles)
            //modelBuilder.Entity<EmployeeRole>().HasData(
            //    new EmployeeRole { EmployeeId = 1, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            //    new EmployeeRole { EmployeeId = 2, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            //    new EmployeeRole { EmployeeId = 3, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now }
            //);

            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Identity = "123456789", FirstName = "John", LastName = "Doe", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 1, 1), MaleOrFmale = true, Status = true, CompanyId = 1 },
            new Employee { Id = 2, Identity = "987654321", FirstName = "Jane", LastName = "Smith", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 5, 5), MaleOrFmale = false, Status = true, CompanyId = 2 },
            new Employee { Id = 3, Identity = "456789123", FirstName = "Alice", LastName = "Johnson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 10, 10), MaleOrFmale = true, Status = false, CompanyId = 1 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Manager" },
                new Role { Id = 2, RoleName = "Developer" },
                new Role { Id = 3, RoleName = "Designer" }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "company1", Password = "123456" },
                new Company { Id = 2, Name = "company2", Password = "123456" },
                new Company { Id = 3, Name = "company3", Password = "123456" }
            );
            modelBuilder.Entity<EmployeeRole>().HasData(
            new EmployeeRole { EmployeeId = 1, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 2, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now }
            );
        }


    }
}
