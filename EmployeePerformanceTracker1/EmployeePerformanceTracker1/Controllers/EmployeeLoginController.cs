using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EmployeePerformanceTracker1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using EmployeePerformanceTracker1.Services;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoginController : Controller
    {

        private IConfiguration _configuration;
        private readonly EPTDBContext _context;
        private readonly UserIdService _userIdService;
        public EmployeeLoginController(IConfiguration configuration, EPTDBContext context, UserIdService userIdService)
        {
            _configuration = configuration;
            _context = context;
            _userIdService = userIdService;
        }

        #region Login part
        [HttpPost]
        public async Task<IActionResult> EmployeeLogin([FromBody] Login login)
        {
            try
            {
                int result = await _userIdService.GetEmployeeId(login.Email);
                var user = Authenticate(login);
                if (user != null)
                {
                    var token = Generate(user);
                    User employee = new User();
                    employee.token = token;
                    employee.UserId = result;
                    //var obj = new { Token = token };
                    return Ok(employee);

                }
                return BadRequest("Login not possible");
            }
            catch(Exception) { return BadRequest("Login not possible"); }
        }
        #endregion

        #region authenticate part
        private Employee Authenticate(Login employeelogin)
        {
            var e1 = _context.Employees.FirstOrDefault(
                e => e.EmailId == employeelogin.Email && e.Password == employeelogin.Password && e.JobRole == employeelogin.Role);
            if (e1 != null)
            {
                return e1;
            }
            return null;
        }
        #endregion

        #region Generate token
        private string Generate(Employee employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,employee.EmailId),
                new Claim(ClaimTypes.NameIdentifier,employee.Password),
                new Claim(ClaimTypes.NameIdentifier,employee.EmployeeName),
                new Claim(ClaimTypes.Role,employee.JobRole)
            };
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"],
                                             _configuration["JWT:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        #endregion
    }
}
