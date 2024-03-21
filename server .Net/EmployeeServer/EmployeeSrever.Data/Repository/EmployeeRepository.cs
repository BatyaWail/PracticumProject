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
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public  async Task<Employee> AddAsync(Employee employee)
        {
            //foreach(var role in employee.EmployeeRoles)
            //{
            //    var existingRole = _dataContext.Roles.Find(role.Role.Id);
            //    if (existingRole == null)
            //    {
            //        throw new InvalidOperationException($"Role with ID {role.Role.Id} not found.");
            //    }

            //    // Update existingRole with values from the provided role object
            //    existingRole.RoleName = role.Role.RoleName;
            //    existingRole.IsManagementRole = role.Role.IsManagementRole;

            //}
            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _dataContext.Employees.Include(u => u.EmployeeRoles).FirstOrDefaultAsync(x => id == x.Identity);
        }
        public  async Task<List<Employee>> GetListAsync()
        {
            //return _dataContext.Employees.Include(u => u.Station).ToList();
            return await _dataContext.Employees.Include(e=>e.EmployeeRoles).ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            //var employee = GetById(id);
            var existingEmployee = _dataContext.Employees.FirstOrDefault(x => id == x.Identity);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {id} not found.");
            }
            existingEmployee.Status = false;
            //_dataContext.Employees.Remove(_dataContext.Employees.ToList().FirstOrDefault(x=>id==x.Identity));
           await _dataContext.SaveChangesAsync();
        }

        //public Employee Update(int id, Employee employee)
        //{
        //    int x = _dataContext.Employees.ToList().FindIndex(x => x.Id == id);
        //    _dataContext.Employees.ToList()[x] = employee;
        //    _dataContext.SaveChanges();
        //    return employee;
        //}
        //public Employee Update(string id, Employee employee)
        //{
        //    var existingEmployee = _dataContext.Employees.Find(id);
        //    if (existingEmployee == null)
        //    {
        //        throw new InvalidOperationException($"Employee with ID {id} not found.");
        //    }

        //    // Update existingEmployee with values from the provided employee object
        //    existingEmployee.FirstName = employee.FirstName;
        //    existingEmployee.LastName = employee.LastName;
        //    existingEmployee.StartDate = employee.StartDate;
        //    existingEmployee.DateOfBirth = employee.DateOfBirth;
        //    existingEmployee.Gender = employee.Gender;
        //    existingEmployee.Status = employee.Status;
        //    _dataContext.SaveChanges();

        //    return existingEmployee;
        //}
        public async Task<Employee> UpdateAsync(string id, Employee employee)
        {
            var existingEmployee = _dataContext.Employees.FirstOrDefault(x => id == x.Identity);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {id} not found.");
            }

            //// Update existingEmployee with values from the provided employee object
            //existingEmployee.FirstName = employee.FirstName;
            //existingEmployee.LastName = employee.LastName;
            //existingEmployee.StartDate = employee.StartDate;
            //existingEmployee.DateOfBirth = employee.DateOfBirth;
            //existingEmployee.Gender = employee.Gender;
            //existingEmployee.Status = employee.Status;
            existingEmployee = employee;

            await _dataContext.SaveChangesAsync();

            return existingEmployee;
        }

        
        //var existEmployee = GetById(id);
        //_dataContext.Entry(existEmployee).CurrentValues.SetValues(employee);
        //var existCustomer = await GetByIdAsync(customer.Id);
        //_dataContext.Entry(existCustomer).CurrentValues.SetValues(customer);
        //    await _dataContext.SaveChangesAsync();
        //    return existCustomer;
    }
}
