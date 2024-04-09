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
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employee-Db");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
        //}
        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Identity = "123456789", FirstName = "John", LastName = "Doe", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 1, 1), MaleOrFmale = true, Status = true, CompanyId = 1 },
            new Employee { Id = 2, Identity = "987654321", FirstName = "Jane", LastName = "Smith", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 5, 5), MaleOrFmale = false, Status = true, CompanyId = 2 },
            new Employee { Id = 3, Identity = "456789123", FirstName = "Alice", LastName = "Johnson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 10, 10), MaleOrFmale = true, Status = false, CompanyId = 1 },
            // Company 1 Employees
            new Employee { Id = 4, Identity = "111111111", FirstName = "Michael", LastName = "Brown", StartDate = DateTime.Now, DateOfBirth = new DateTime(1988, 3, 15), MaleOrFmale = true, Status = true, CompanyId = 1 },
            new Employee { Id = 5, Identity = "222222222", FirstName = "Emily", LastName = "Jones", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 7, 20), MaleOrFmale = false, Status = true, CompanyId = 1 },
            new Employee { Id = 6, Identity = "333333333", FirstName = "David", LastName = "Wilson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1979, 5, 9), MaleOrFmale = true, Status = true, CompanyId = 1 },
            new Employee { Id = 7, Identity = "444444444", FirstName = "Emma", LastName = "Taylor", StartDate = DateTime.Now, DateOfBirth = new DateTime(1996, 10, 5), MaleOrFmale = false, Status = true, CompanyId = 1 },
            new Employee { Id = 8, Identity = "555555555", FirstName = "Olivia", LastName = "Anderson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 12, 30), MaleOrFmale = false, Status = true, CompanyId = 1 },
            new Employee { Id = 9, Identity = "666666666", FirstName = "Daniel", LastName = "Martinez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1983, 9, 12), MaleOrFmale = true, Status = true, CompanyId = 1 },
            new Employee { Id = 10, Identity = "777777777", FirstName = "Sophia", LastName = "Garcia", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 6, 25), MaleOrFmale = false, Status = true, CompanyId = 1 },

            // Company 2 Employees
            new Employee { Id = 11, Identity = "888888888", FirstName = "Matthew", LastName = "Rodriguez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1976, 4, 18), MaleOrFmale = true, Status = true, CompanyId = 2 },
            new Employee { Id = 12, Identity = "999999999", FirstName = "Isabella", LastName = "Lopez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1991, 8, 8), MaleOrFmale = false, Status = true, CompanyId = 2 },
            new Employee { Id = 13, Identity = "101010101", FirstName = "Ethan", LastName = "Hernandez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1980, 2, 27), MaleOrFmale = true, Status = true, CompanyId = 2 },
            new Employee { Id = 14, Identity = "121212121", FirstName = "Ava", LastName = "Gonzalez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1994, 11, 10), MaleOrFmale = false, Status = true, CompanyId = 2 },
            new Employee { Id = 15, Identity = "131313131", FirstName = "Alexander", LastName = "Perez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1989, 7, 3), MaleOrFmale = true, Status = true, CompanyId = 2 },
            new Employee { Id = 16, Identity = "141414141", FirstName = "Mia", LastName = "Sanchez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1987, 5, 14), MaleOrFmale = false, Status = true, CompanyId = 2 },
            new Employee { Id = 17, Identity = "151515151", FirstName = "William", LastName = "Ramirez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1992, 9, 28), MaleOrFmale = true, Status = true, CompanyId = 2 },

            // Company 3 Employees
            new Employee { Id = 18, Identity = "161616161", FirstName = "Charlotte", LastName = "Torres", StartDate = DateTime.Now, DateOfBirth = new DateTime(1984, 6, 7), MaleOrFmale = false, Status = true, CompanyId = 3 },
            new Employee { Id = 19, Identity = "171717171", FirstName = "James", LastName = "Nguyen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 12, 19), MaleOrFmale = true, Status = true, CompanyId = 3 },
            new Employee { Id = 20, Identity = "181818181", FirstName = "Amelia", LastName = "Kim", StartDate = DateTime.Now, DateOfBirth = new DateTime(1982, 3, 25), MaleOrFmale = false, Status = true, CompanyId = 3 },
            new Employee { Id = 21, Identity = "191919191", FirstName = "Benjamin", LastName = "Tran", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 10, 31), MaleOrFmale = true, Status = true, CompanyId = 3 },
            new Employee { Id = 22, Identity = "202020202", FirstName = "Harper", LastName = "Chen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1986, 8, 12), MaleOrFmale = false, Status = true, CompanyId = 3 },
            new Employee { Id = 23, Identity = "212121212", FirstName = "Jacob", LastName = "Wang", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 2, 8), MaleOrFmale = true, Status = true, CompanyId = 3 },
            new Employee { Id = 24, Identity = "222222222", FirstName = "Evelyn", LastName = "Wu", StartDate = DateTime.Now, DateOfBirth = new DateTime(1981, 11, 5), MaleOrFmale = false, Status = true, CompanyId = 3 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Developer" },
                new Role { RoleId = 2, RoleName = "Designer" },
                new Role { RoleId = 3, RoleName = "Accountant" },
                new Role { RoleId = 4, RoleName = "Sales Representative" },
                new Role { RoleId = 5, RoleName = "Customer Service Representative" },
                new Role { RoleId = 6, RoleName = "Human Resources Specialist" },
                new Role { RoleId = 7, RoleName = "Marketing Coordinator" }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "company1", Password = "123456" },
                new Company { Id = 2, Name = "company2", Password = "123456" },
                new Company { Id = 3, Name = "company3", Password = "123456" }
            );
            modelBuilder.Entity<EmployeeRole>().HasData(
            new EmployeeRole { EmployeeId = 1, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 1, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 1, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 2, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 2, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 2, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 3, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 3, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 4, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 4, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 4, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 5, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 5, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 5, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 6, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 6, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 6, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 7, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 7, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 7, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 8, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 8, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 9, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 9, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 10, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 10, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 11, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 11, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 11, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 12, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 12, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 12, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 13, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 13, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 13, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 13, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 13, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 13, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 14, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 14, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 14, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 15, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 15, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 15, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 16, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 16, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 16, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 17, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 17, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 17, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

             new EmployeeRole { EmployeeId = 18, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 18, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 19, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 19, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 20, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 20, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 21, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 21, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 21, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 22, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 22, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 22, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 23, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 23, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 23, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 23, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 23, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 23, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

            new EmployeeRole { EmployeeId = 24, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 24, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
            new EmployeeRole { EmployeeId = 24, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now }
            );
        }
    }
}
