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
    public class EmployeeService:IEmployeeService
    {
        //private readonly IClientRepository _clientRepository;
        //public ClientServices(IClientRepository clientRepository)
        //{
        //    _clientRepository = clientRepository;
        //}
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task<List<Employee>> GetEmployeesListAsync()
        {
            return await _employeeRepository.GetListAsync();
        }

        public async Task RemoveEmployeeAsync(string id)
        {
           await _employeeRepository.RemoveAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(string id, Employee employee)
        {
            return await _employeeRepository.UpdateAsync(id, employee);
        }
    }
}
