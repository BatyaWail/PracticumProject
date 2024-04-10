using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.Model
{
    public class CompanyToPost
    {
        public int Id { get; set; }
        //public string UserName { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
