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
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Role> AddAsync(Role role)
        {
            _dataContext.Roles.Add(role);
           await _dataContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _dataContext.Roles.Include(r => r.EmployeeRoles).FirstAsync(x => x.Id == id);
        }
        public async Task<Role> GetByNameAsync(string name)
        {
            return await _dataContext.Roles.Include(r => r.EmployeeRoles).FirstOrDefaultAsync(x => x.RoleName == name);
        }
        public async Task<List<Role>> GetListAsync()
        {
            //return _dataContext.Employees.Include(u => u.Station).ToList();
            return await _dataContext.Roles.Include(r=>r.EmployeeRoles).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _dataContext.Roles.Remove(_dataContext.Roles.ToList().Find(x => x.Id == id));
           await _dataContext.SaveChangesAsync();
        }

        //public Role Update(int id, Role role)
        //{
        //    int x = _dataContext.Roles.ToList().FindIndex(x => x.Id == id);
        //    _dataContext.Roles.ToList()[x] = role;
        //    _dataContext.SaveChanges();
        //    return role;
        //}
        //public Role Update(int id, Role role)
        //{
        //    var existingRole = _dataContext.Roles.Find(id);
        //    if (existingRole == null)
        //    {
        //        throw new InvalidOperationException($"Role with ID {id} not found.");
        //    }
        //    // Update existingRole with values from the provided role object
        //    existingRole.RoleName = role.RoleName;
        //    existingRole.IsManagementRole = role.IsManagementRole;
        //    existingRole.EntryDate = role.EntryDate;

        //    _dataContext.SaveChanges();

        //    return existingRole;
        //}
        public async Task<Role> UpdateAsync(int id, Role role)
        {
            var existingRole = _dataContext.Roles.Find(id);
            if (existingRole == null)
            {
                throw new InvalidOperationException($"Role with ID {id} not found.");
            }

            // Update existingRole with values from the provided role object
            existingRole.RoleName = role.RoleName;
            //existingRole.IsManagementRole = role.IsManagementRole;
            //existingRole.EntryDate = role.EntryDate;

            await _dataContext.SaveChangesAsync();

            return existingRole;
        }

       
    }
}
