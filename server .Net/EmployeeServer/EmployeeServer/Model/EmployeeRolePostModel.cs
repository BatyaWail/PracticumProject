using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.Model
{
    public class EmployeeRolePostModel
    {
        //public int EmployeeId { get; set; }

        public RolePostModel Role { get; set; }

        // תוספת כלשהי, אם רצוי
        // public DateTime AssignedDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
