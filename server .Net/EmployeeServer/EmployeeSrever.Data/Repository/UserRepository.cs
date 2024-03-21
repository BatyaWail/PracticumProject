using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<User> GetByUserNameAndPaswword(string userName,string paswword)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == paswword);
        }
       
    }
}
