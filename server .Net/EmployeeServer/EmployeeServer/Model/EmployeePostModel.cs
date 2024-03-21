﻿using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.Model
{
    public class EmployeePostModel
    {
        //public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        //public List<Role> Role { get; set; }
        public List<EmployeeRolePostModel> EmployeeRoles { get; set; } // הוספה
        //public bool Status { get; set; }
    }
}