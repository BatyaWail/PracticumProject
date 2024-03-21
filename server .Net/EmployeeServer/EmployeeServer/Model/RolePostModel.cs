using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.Model
{
    public class RolePostModel
    {
        public string RoleName { get; set; }
        public bool IsManagementRole { get; set; }
        //public List<int> EmployeesId { get; set; }
    }
}
