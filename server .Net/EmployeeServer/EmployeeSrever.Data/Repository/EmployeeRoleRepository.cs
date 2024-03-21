﻿using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data.Repository
{
    public class EmployeeRoleRepository:IEmployeeRoleRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<EmployeeRole> GetByEmployeeIdAndRoleIdAsync(string employeeId,int roleId)
        {
            var x= await _dataContext.EmployeeRoles.Include(e=>e.Employee).FirstOrDefaultAsync(e => e.Employee.Identity == employeeId && e.RoleId == roleId);
            return x;
        }
    }
}
