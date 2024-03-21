using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using EmployeeServer.Service.Services;
using EmployeeSrever.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService,IRoleService roleService,IMapper mapper)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _employeeService.GetEmployeesListAsync();
            var listDto = new List<EmployeeDto>();
            foreach (var employee in list)
            {
                listDto.Add(_mapper.Map<EmployeeDto>(employee));
            }
            return Ok(listDto);
        }
        //public ActionResult Get()
        //{
        //    var list = _employeeService.GetEmployeesList();
        //    return Ok(list);
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var employee=await _employeeService.GetEmployeeByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employeePostModel)
        {
            // Map EmployeePostModel to Employee
            var employee = _mapper.Map<Employee>(employeePostModel);

            // Assuming you have current employee available, you can add EmployeeRole to it
            // Here, you might want to set EmployeeId for each EmployeeRole based on the current employee
            foreach (var employeeRole in employee.EmployeeRoles)
            {
                employeeRole.EmployeeId = employee.Id; // Employee.Id is of type string
            }
            // Add employee to database or perform any other operation
            // dbContext.Employees.Add(employee);
            // dbContext.SaveChanges();
            employee.Status = true;
            return Ok(_mapper.Map<EmployeeDto>(
                await _employeeService.AddEmployeeAsync(employee)));
            ////Employee newEmployee = new Employee()
            ////{

            ////};
            ////List<EmployeeRole> employeeRoles = new List<EmployeeRole>();
            ////foreach(var i in employee.EmployeeRoles)
            ////{
            ////    employeeRoles.Add(_mapper.Map<EmployeeRole>(new EmployeeRolePostModel() { EmployeeId=employee})
            ////}
            //Employee employee2 = _mapper.Map<Employee>(employee);
            //return Ok(_employeeService.AddEmployee(employee2));
        }
        //public  ActionResult Post([FromBody] Employee employee)
        //{
        //    var newEmployee =  _employeeService.AddEmployee(_mapper.Map<Employee>(employee));
        //    if (newEmployee != null)
        //    {
        //        NotFound();
        //    }
        //    return Ok(_mapper.Map<EmployeeDto>(newEmployee));
        //}

        // PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        //public ActionResult Put(string id, [FromBody] EmployeePostModel employeePostModel)
        //{
        //    var employee =  _employeeService.GetEmployeeById(id);

        //    // If employee doesn't exist, return NotFound
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    // Map updated data to the existing employee entity
        //    _mapper.Map(employeePostModel, employee);

        //    // Update the employee in the database
        //    _employeeService.UpdateEmployee(id,employee);

        //    // Return Ok response
        //    return Ok();
        //}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] EmployeePostModel employeePostModel)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            // If employee doesn't exist, return NotFound
            if (employee == null)
            {
                return NotFound();
            }

            // Map updated data from EmployeePostModel to the existing employee entity
            _mapper.Map(employeePostModel, employee);

            // Update the employee in the database
            var employee2= await _employeeService.UpdateEmployeeAsync(id, employee);

            // Return Ok response
            return Ok(_mapper.Map<EmployeeDto>(employee2));
        }

        //[HttpPut("{id}")]
        //public ActionResult Put(string id, [FromBody] EmployeePostModel employeePostModel)
        //{
        //    var employee = _employeeService.GetEmployeeById(id);

        //    // If employee doesn't exist, return NotFound
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update scalar properties of the employee
        //    employee.FirstName = employeePostModel.FirstName;
        //    employee.LastName = employeePostModel.LastName;
        //    employee.Identity = employeePostModel.Identity;
        //    employee.StartDate = employeePostModel.StartDate;
        //    employee.DateOfBirth = employeePostModel.DateOfBirth;
        //    employee.Gender = employeePostModel.Gender;
        //    employee.Status = employeePostModel.Status;

        //    // Update employee roles
        //    foreach (var employeeRole in employeePostModel.EmployeeRoles)
        //    {
        //        var roleId = employeeRole.Role.Id; // Assuming the role ID is provided in the DTO

        //        var role = _roleService.GetRoleById(roleId);

        //        if (role == null)
        //        {
        //            // Role doesn't exist, return BadRequest or handle the scenario accordingly
        //            return BadRequest($"Role with ID {roleId} not found.");
        //        }

        //        // Check if the employee already has this role
        //        var existingEmployeeRole = employee.EmployeeRoles.FirstOrDefault(er => er.RoleId == roleId);
        //        if (existingEmployeeRole != null)
        //        {
        //            // Update the entry date of the existing role
        //            existingEmployeeRole.EntryDate = employeeRole.EntryDate;
        //        }
        //        else
        //        {
        //            // Create a new employee role
        //            var newEmployeeRole = new EmployeeRole
        //            {
        //                EmployeeId = employee.Id,
        //                Employee = employee,
        //                RoleId = roleId,
        //                Role = role,
        //                EntryDate = employeeRole.EntryDate
        //            };
        //            employee.EmployeeRoles.Add(newEmployeeRole);
        //        }
        //    }

        //    // Update the employee in the database
        //    _employeeService.UpdateEmployee(id, employee);

        //    // Return Ok response
        //    return Ok();
        //}



        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var employee= await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeService.RemoveEmployeeAsync(id);
            return NoContent();
        }
    }
}
