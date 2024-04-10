////using EmployeeServer.Core.Entities;
////using Microsoft.EntityFrameworkCore;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace EmployeeSrever.Data
////{
////    public class DataContext : DbContext
////    {
////        public DbSet<Employee> Employees { get; set; }
////        public DbSet<Role> Roles { get; set; }
////        public DbSet<Company> Companies { get; set; }
////        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employee-Db3");
////        }

////        protected override void OnModelCreating(ModelBuilder modelBuilder)
////        {
////            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
////            modelBuilder.Entity<Employee>().HasData(
////            new Employee { Id = 1, Identity = "123456789", FirstName = "Miriam", LastName = "Levy", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 1, 1), MaleOrFmale = true, Status = true, CompanyId = 1 },
////            new Employee { Id = 2, Identity = "987654321", FirstName = "David", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 5, 5), MaleOrFmale = false, Status = true, CompanyId = 2 },
////            new Employee { Id = 3, Identity = "456789123", FirstName = "Yael", LastName = "Goldshtein", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 10, 10), MaleOrFmale = true, Status = false, CompanyId = 1 },
////            // Company 1 Employees
////            new Employee { Id = 4, Identity = "111111111", FirstName = "Eitan", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1988, 3, 15), MaleOrFmale = true, Status = true, CompanyId = 1 },
////            new Employee { Id = 5, Identity = "222222222", FirstName = "Adi", LastName = "Levi", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 7, 20), MaleOrFmale = false, Status = true, CompanyId = 1 },
////            new Employee { Id = 6, Identity = "333333333", FirstName = "Yosef", LastName = "Weiss", StartDate = DateTime.Now, DateOfBirth = new DateTime(1979, 5, 9), MaleOrFmale = true, Status = true, CompanyId = 1 },
////            new Employee { Id = 7, Identity = "444444444", FirstName = "Shira", LastName = "Rosen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1996, 10, 5), MaleOrFmale = false, Status = true, CompanyId = 1 },
////            new Employee { Id = 8, Identity = "555555555", FirstName = "Avi", LastName = "Friedman", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 12, 30), MaleOrFmale = false, Status = true, CompanyId = 1 },
////            new Employee { Id = 9, Identity = "666666666", FirstName = "Tamar", LastName = "Shapiro", StartDate = DateTime.Now, DateOfBirth = new DateTime(1983, 9, 12), MaleOrFmale = true, Status = true, CompanyId = 1 },
////            new Employee { Id = 10, Identity = "777777777", FirstName = "Avraham", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 6, 25), MaleOrFmale = false, Status = true, CompanyId = 1 },

////            // Company 2 Employees
////            new Employee { Id = 11, Identity = "888888888", FirstName = "Yonatan", LastName = "Levy", StartDate = DateTime.Now, DateOfBirth = new DateTime(1976, 4, 18), MaleOrFmale = true, Status = true, CompanyId = 2 },
////            new Employee { Id = 12, Identity = "999999999", FirstName = "Yael", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1991, 8, 8), MaleOrFmale = false, Status = true, CompanyId = 2 },
////            new Employee { Id = 13, Identity = "101010101", FirstName = "Yitzhak", LastName = "Levi", StartDate = DateTime.Now, DateOfBirth = new DateTime(1980, 2, 27), MaleOrFmale = true, Status = true, CompanyId = 2 },
////            new Employee { Id = 14, Identity = "121212121", FirstName = "Rivka", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1994, 11, 10), MaleOrFmale = false, Status = true, CompanyId = 2 },
////            new Employee { Id = 15, Identity = "131313131", FirstName = "Moshe", LastName = "Levy", StartDate = DateTime.Now, DateOfBirth = new DateTime(1989, 7, 3), MaleOrFmale = true, Status = true, CompanyId = 2 },
////            new Employee { Id = 16, Identity = "141414141", FirstName = "Hanna", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1987, 5, 14), MaleOrFmale = false, Status = true, CompanyId = 2 },
////            new Employee { Id = 17, Identity = "151515151", FirstName = "Yosef", LastName = "Levi", StartDate = DateTime.Now, DateOfBirth = new DateTime(1992, 9, 28), MaleOrFmale = true, Status = true, CompanyId = 2 },

////            // Company 3 Employees
////            new Employee { Id = 18, Identity = "161616161", FirstName = "Miriam", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1984, 6, 7), MaleOrFmale = false, Status = true, CompanyId = 3 },
////            new Employee { Id = 19, Identity = "171717171", FirstName = "Yaakov", LastName = "Levy", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 12, 19), MaleOrFmale = true, Status = true, CompanyId = 3 },
////            new Employee { Id = 20, Identity = "181818181", FirstName = "Adina", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1982, 3, 25), MaleOrFmale = false, Status = true, CompanyId = 3 },
////            new Employee { Id = 21, Identity = "191919191", FirstName = "Binyamin", LastName = "Levi", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 10, 31), MaleOrFmale = true, Status = true, CompanyId = 3 },
////            new Employee { Id = 22, Identity = "202020202", FirstName = "Chaya", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1986, 8, 12), MaleOrFmale = false, Status = true, CompanyId = 3 },
////            new Employee { Id = 23, Identity = "212121212", FirstName = "Yaakov", LastName = "Levi", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 2, 8), MaleOrFmale = true, Status = true, CompanyId = 3 },
////            new Employee { Id = 24, Identity = "222222222", FirstName = "Efrat", LastName = "Cohen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1981, 11, 5), MaleOrFmale = false, Status = true, CompanyId = 3 }
////            );

////            modelBuilder.Entity<Role>().HasData(
////                new Role { RoleId = 1, RoleName = "Developer" },
////                new Role { RoleId = 2, RoleName = "Designer" },
////                new Role { RoleId = 3, RoleName = "Accountant" },
////                new Role { RoleId = 4, RoleName = "Sales" },
////                new Role { RoleId = 5, RoleName = "Marketing" }
////            );

////            modelBuilder.Entity<Company>().HasData(
////                new Company { Id = 1, Name = "company1", Password = "123456" },
////                new Company { Id = 2, Name = "company2", Password = "123456" },
////                new Company { Id = 3, Name = "company3", Password = "123456" }
////            );
////            modelBuilder.Entity<EmployeeRole>().HasData(
////            new EmployeeRole { EmployeeId = 1, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 1, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 1, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 2, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 2, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 2, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

////            new EmployeeRole { EmployeeId = 3, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 3, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 3, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 3, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 3, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 3, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now },

////            new EmployeeRole { EmployeeId = 4, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 4, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 4, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 5, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 5, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
////            new EmployeeRole { EmployeeId = 5, RoleId = 6, IsManagementRole = false, EntryDate = DateTime.Now }
////            );
////        }
////    }
////}







//using EmployeeServer.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EmployeeSrever.Data
//{
//    public class DataContext : DbContext
//    {
//        public DbSet<Employee> Employees { get; set; }
//        public DbSet<Role> Roles { get; set; }
//        public DbSet<Company> Companies { get; set; }
//        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
//        //DbContextOptionsBuilder
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employee-Db10");
//        }
//        //protected override void OnModelCreating(ModelBuilder modelBuilder)
//        //{
//        //    modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
//        //}
//        // Seed data
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });
//            modelBuilder.Entity<Employee>().HasData(
//            new Employee { Id = 1, Identity = "123456789", FirstName = "John", LastName = "Doe", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 1, 1), MaleOrFmale = true, Status = true, CompanyId = 1 },
//            new Employee { Id = 2, Identity = "987654321", FirstName = "Jane", LastName = "Smith", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 5, 5), MaleOrFmale = false, Status = true, CompanyId = 2 },
//            new Employee { Id = 3, Identity = "456789123", FirstName = "Alice", LastName = "Johnson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 10, 10), MaleOrFmale = true, Status = false, CompanyId = 1 },
//            // Company 1 Employees
//            new Employee { Id = 4, Identity = "111111111", FirstName = "Michael", LastName = "Brown", StartDate = DateTime.Now, DateOfBirth = new DateTime(1988, 3, 15), MaleOrFmale = true, Status = true, CompanyId = 1 },
//            new Employee { Id = 5, Identity = "222222222", FirstName = "Emily", LastName = "Jones", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 7, 20), MaleOrFmale = false, Status = true, CompanyId = 1 },
//            new Employee { Id = 6, Identity = "333333333", FirstName = "David", LastName = "Wilson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1979, 5, 9), MaleOrFmale = true, Status = true, CompanyId = 1 },
//            new Employee { Id = 7, Identity = "444444444", FirstName = "Emma", LastName = "Taylor", StartDate = DateTime.Now, DateOfBirth = new DateTime(1996, 10, 5), MaleOrFmale = false, Status = true, CompanyId = 1 },
//            new Employee { Id = 8, Identity = "555555555", FirstName = "Olivia", LastName = "Anderson", StartDate = DateTime.Now, DateOfBirth = new DateTime(1985, 12, 30), MaleOrFmale = false, Status = true, CompanyId = 1 },
//            new Employee { Id = 9, Identity = "666666666", FirstName = "Daniel", LastName = "Martinez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1983, 9, 12), MaleOrFmale = true, Status = true, CompanyId = 1 },
//            new Employee { Id = 10, Identity = "777777777", FirstName = "Sophia", LastName = "Garcia", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 6, 25), MaleOrFmale = false, Status = true, CompanyId = 1 },

//            // Company 2 Employees
//            new Employee { Id = 11, Identity = "888888888", FirstName = "Matthew", LastName = "Rodriguez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1976, 4, 18), MaleOrFmale = true, Status = true, CompanyId = 2 },
//            new Employee { Id = 12, Identity = "999999999", FirstName = "Isabella", LastName = "Lopez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1991, 8, 8), MaleOrFmale = false, Status = true, CompanyId = 2 },
//            new Employee { Id = 13, Identity = "101010101", FirstName = "Ethan", LastName = "Hernandez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1980, 2, 27), MaleOrFmale = true, Status = true, CompanyId = 2 },
//            new Employee { Id = 14, Identity = "121212121", FirstName = "Ava", LastName = "Gonzalez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1994, 11, 10), MaleOrFmale = false, Status = true, CompanyId = 2 },
//            new Employee { Id = 15, Identity = "131313131", FirstName = "Alexander", LastName = "Perez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1989, 7, 3), MaleOrFmale = true, Status = true, CompanyId = 2 },
//            new Employee { Id = 16, Identity = "141414141", FirstName = "Mia", LastName = "Sanchez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1987, 5, 14), MaleOrFmale = false, Status = true, CompanyId = 2 },
//            new Employee { Id = 17, Identity = "151515151", FirstName = "William", LastName = "Ramirez", StartDate = DateTime.Now, DateOfBirth = new DateTime(1992, 9, 28), MaleOrFmale = true, Status = true, CompanyId = 2 },

//            // Company 3 Employees
//            new Employee { Id = 18, Identity = "161616161", FirstName = "Charlotte", LastName = "Torres", StartDate = DateTime.Now, DateOfBirth = new DateTime(1984, 6, 7), MaleOrFmale = false, Status = true, CompanyId = 3 },
//            new Employee { Id = 19, Identity = "171717171", FirstName = "James", LastName = "Nguyen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1993, 12, 19), MaleOrFmale = true, Status = true, CompanyId = 3 },
//            new Employee { Id = 20, Identity = "181818181", FirstName = "Amelia", LastName = "Kim", StartDate = DateTime.Now, DateOfBirth = new DateTime(1982, 3, 25), MaleOrFmale = false, Status = true, CompanyId = 3 },
//            new Employee { Id = 21, Identity = "191919191", FirstName = "Benjamin", LastName = "Tran", StartDate = DateTime.Now, DateOfBirth = new DateTime(1995, 10, 31), MaleOrFmale = true, Status = true, CompanyId = 3 },
//            new Employee { Id = 22, Identity = "202020202", FirstName = "Harper", LastName = "Chen", StartDate = DateTime.Now, DateOfBirth = new DateTime(1986, 8, 12), MaleOrFmale = false, Status = true, CompanyId = 3 },
//            new Employee { Id = 23, Identity = "212121212", FirstName = "Jacob", LastName = "Wang", StartDate = DateTime.Now, DateOfBirth = new DateTime(1990, 2, 8), MaleOrFmale = true, Status = true, CompanyId = 3 },
//            new Employee { Id = 24, Identity = "222222222", FirstName = "Evelyn", LastName = "Wu", StartDate = DateTime.Now, DateOfBirth = new DateTime(1981, 11, 5), MaleOrFmale = false, Status = true, CompanyId = 3 }
//            );

//            modelBuilder.Entity<Role>().HasData(
//                new Role { RoleId = 1, RoleName = "Developer" },
//                new Role { RoleId = 2, RoleName = "Developer" },
//                new Role { RoleId = 3, RoleName = "Designer" },
//                new Role { RoleId = 4, RoleName = "Accountant" },
//                new Role { RoleId = 5, RoleName = "Marketing Coordinator" }
//            );

//            modelBuilder.Entity<Company>().HasData(
//                new Company { Id = 1, Name = "company1", Password = "123456" },
//                new Company { Id = 2, Name = "company2", Password = "123456" },
//                new Company { Id = 3, Name = "company3", Password = "123456" }
//            );
//            modelBuilder.Entity<EmployeeRole>().HasData(
//            new EmployeeRole { EmployeeId = 1, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 1, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 1, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 2, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 2, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 2, RoleId = 1, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 3, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 3, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 3, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 3, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 3, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 3, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 4, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 4, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 4, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 5, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 5, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 5, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 6, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 6, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 6, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 7, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 7, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 7, RoleId = 4, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 8, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 8, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 9, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 9, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 10, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 10, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 11, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 11, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 11, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 12, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 12, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 12, RoleId = 1, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 13, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 13, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 13, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 13, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 13, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 13, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 14, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 14, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 14, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 15, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 15, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 15, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 16, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 16, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 16, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 17, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 17, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 17, RoleId = 4, IsManagementRole = false, EntryDate = DateTime.Now },

//             new EmployeeRole { EmployeeId = 18, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 18, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 19, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 19, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 20, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 20, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 21, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 21, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 21, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 22, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 22, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 22, RoleId = 1, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 23, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 23, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 23, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 23, RoleId = 4, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 23, RoleId = 5, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 23, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },

//            new EmployeeRole { EmployeeId = 24, RoleId = 1, IsManagementRole = true, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 24, RoleId = 2, IsManagementRole = false, EntryDate = DateTime.Now },
//            new EmployeeRole { EmployeeId = 24, RoleId = 3, IsManagementRole = false, EntryDate = DateTime.Now }
//            );
//        }
//    }
//}
using EmployeeServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employee-Db1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });

            // Seed data for Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "company1", Password = "123456" },
                new Company { Id = 2, Name = "company2", Password = "123456" },
                new Company { Id = 3, Name = "company3", Password = "123456" }
            );

            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Developer" },
                new Role { RoleId = 2, RoleName = "Designer" },
                new Role { RoleId = 3, RoleName = "Manager" },
                new Role { RoleId = 4, RoleName = "Accountant" }
            );

            // Generate random Jewish names for employees (in English)
            var random = new Random();
            var jewishFirstNames = new List<string> { "David", "Abraham", "Moses", "Joseph", "Rebecca", "Leah", "Sarah", "Miriam", "Esther", "Batya", "Shoshana", "Ruth", "Rachel", "Hannah", "Aaron", "Isaac", "Jacob", "Samuel", "Solomon", "Elijah" };
            var jewishLastNames = new List<string> { "Cohen", "Levi", "Goldberg", "Stein", "Katz", "Rosenberg", "Segal", "Weiss", "Adler", "Friedman", "Shapiro", "Gross", "Geller", "Stern", "Blum", "Zimmerman", "Sandler", "Schwartz", "Gordon", "Klein" };

            // Seed data for Employees
            var employees = new List<Employee>();
            for (int i = 0; i < 30; i++)
            {
                var firstName = jewishFirstNames[random.Next(jewishFirstNames.Count)];
                var lastName = jewishLastNames[random.Next(jewishLastNames.Count)];
                var identity = (i + 1).ToString().PadLeft(9, '0'); // Assuming sequential IDs as identity
                var startDate = DateTime.Now.AddMonths(-random.Next(1, 12)); // Random start date within the past year
                var dateOfBirth = DateTime.Now.AddYears(-random.Next(18, 60)); // Random date of birth between 18 and 60 years ago
                var companyId = random.Next(1, 4); // Random company ID
                var employee = new Employee { Id = i + 1, Identity = identity, FirstName = firstName, LastName = lastName, StartDate = startDate, DateOfBirth = dateOfBirth, MaleOrFmale = random.Next(2) == 0, Status = true, CompanyId = companyId };
                employees.Add(employee);
            }
            modelBuilder.Entity<Employee>().HasData(employees);

            // Seed data for EmployeeRoles
            var employeeRoles = new List<EmployeeRole>();
            foreach (var employee in employees)
            {
                var rolesCount = random.Next(2, 4); // Assign between 2 to 3 roles to each employee
                var selectedRoles = new List<int>();
                while (selectedRoles.Count < rolesCount)
                {
                    var roleId = random.Next(1, 5); // Randomly select a role
                    if (!selectedRoles.Contains(roleId))
                    {
                        selectedRoles.Add(roleId);
                    }
                }
                foreach (var roleId in selectedRoles)
                {
                    employeeRoles.Add(new EmployeeRole { EmployeeId = employee.Id, RoleId = roleId, IsManagementRole = random.Next(2) == 0, EntryDate = employee.StartDate });
                }
            }
            modelBuilder.Entity<EmployeeRole>().HasData(employeeRoles);
        }

    }
}

