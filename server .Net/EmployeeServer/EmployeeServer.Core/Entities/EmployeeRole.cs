using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Entities
{
    public class EmployeeRole
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // הוספת אטריביוט על מנת להגדיר שה-Id ייווצר באופן אוטומטי
        //public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        // תוספת כלשהי, אם רצוי
        // public DateTime AssignedDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
