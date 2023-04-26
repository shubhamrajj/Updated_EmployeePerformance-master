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
    public class AdminLoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly EPTDBContext _context;
        private readonly UserIdService _userIdService;
        public AdminLoginController(IConfiguration configuration, EPTDBContext context, UserIdService userIdService)
        {
            _configuration = configuration;
            _context = context;
            _userIdService = userIdService;
        }

        #region Login part
        [HttpPost]
        public async Task<IActionResult> AdminLogin([FromBody] Login login)
        {
            try
            {
                int result = await _userIdService.GetAdminId(login.Email);
                var user = Authenticate(login);
                if (user != null)
                {
                    var token = Generate(user);
                    User admin = new User();
                    admin.token = token;

                    admin.UserId = result;
                    // var obj = new { Token = token };
                    return Ok(admin);

                }
                return BadRequest("Login not possible");
            }
            catch(Exception)
            {
                return BadRequest("Login not possible");
            }
        }
        #endregion

        #region authenticate part
        private Admin Authenticate(Login adminlogin)
        {
            var a1 = _context.Admins.FirstOrDefault(
                a => a.EmailId == adminlogin.Email && a.Password == adminlogin.Password && a.JobRole == adminlogin.Role);
            if (a1 != null)
            {
                return a1;
            }
            return null;
        }
        #endregion

        #region Generate token
        private string Generate(Admin admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,admin.EmailId),
                new Claim(ClaimTypes.NameIdentifier,admin.Password),
                new Claim(ClaimTypes.NameIdentifier,admin.AdminName),
                new Claim(ClaimTypes.Role,admin.JobRole)
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
