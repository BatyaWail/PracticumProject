using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetByUserNameAndPaswword(string userName, string paswword)
        {
            return await _userRepository.GetByUserNameAndPaswword(userName, paswword);
        }
    }
}
