using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Dtos
{
    public class EmployeeRoleDto
    {
        public int EmployeeId { get; set; }
        //public EmployeeDto Employee { get; set; }
        public int RoleId { get; set; }
        //public RoleDto Role { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
