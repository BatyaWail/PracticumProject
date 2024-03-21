using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IMapper mapper, IUserService userService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            //var user = _mapper.Map<User>(loginModel);
            var user =await _userService.GetByUserNameAndPaswword(loginModel.UserName, loginModel.Password);

            //if (loginModel.UserName == "malkabr" && loginModel.Password == "123456")
            //{
            //    var claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.Name, "malkabr"),
            //    new Claim(ClaimTypes.Role, "teacher")
            //};

            if (user!=null)
            {
                var claims = new List<Claim>()
            {
                new Claim("id",user.Id.ToString() ),
                new Claim("name",user.UserName),
                new Claim("password",user.Password)
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
            }
            return Unauthorized();
        }
    }

}
