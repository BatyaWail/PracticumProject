﻿using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Dtos
{
    public class EmployeeDto
    {
        //public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        //public List<Role> Role { get; set; }
        public List<EmployeeRoleDto> EmployeeRoles { get; set; } // הוספה
        public bool Status { get; set; }
    }
}