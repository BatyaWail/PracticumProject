using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Services;

//using EmployeeServer.Api.Model;
//using EmployeeServer.Core.Entities;
//using EmployeeServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;


namespace EmployeeServer.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthController : ControllerBase
    //{

    //}
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public AuthController(IConfiguration configuration, IMapper mapper, ICompanyService companyService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var company =await _companyService.GetCompanyByNameAndPaswword(loginModel.Name, loginModel.Password);
            if (company == null)
            {
                //return Request.CreateResponse(HttpStatusCode.Forbidden);
                return StatusCode(403); // או ניתן להחזיר BadRequest()
            }
            var claims = new List<Claim>()
            {
                new Claim("id",company.Id.ToString() ),
                new Claim("name",company.Name),
                new Claim("password",company.Password)
            };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            //}
            //return Unauthorized();
        }
    }

}
