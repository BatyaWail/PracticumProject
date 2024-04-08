using AutoMapper;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly IMapper _mapper;
        public CompanyController(
             IMapper mapper, ICompanyService companyService)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var companiesDto = _mapper.Map<List<CopmanyDto>>(await _companyService.GetCompaniesListAsync());

            return Ok(companiesDto);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
