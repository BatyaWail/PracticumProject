using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        //public bool IsManagementRole { get; set; }
        public List<EmployeeRoleDto> EmployeeRoles { get; set; }
    }
}
