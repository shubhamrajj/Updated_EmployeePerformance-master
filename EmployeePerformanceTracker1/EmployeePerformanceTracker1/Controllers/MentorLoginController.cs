using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EmployeePerformanceTracker1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using EmployeePerformanceTracker1.Services;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorLoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly EPTDBContext _context;
        private readonly UserIdService _userIdService;
        public MentorLoginController(IConfiguration configuration, EPTDBContext context, UserIdService userIdService)
        {
            _configuration = configuration;
            _context = context;
            _userIdService = userIdService;
        }
        #region Login part
        [HttpPost]
        public async Task< IActionResult> MentorLogin([FromBody] Login login)
        {
            try
            {
                int result = await _userIdService.GetMentorId(login.EmailId);
                var user = Authenticate(login);
                if (user != null)
                {
                    var token = Generate(user);
                    User mentor = new User();
                    mentor.token = token;

                    mentor.UserId = result;
                    //var obj = new { Token = token };
                    return Ok(mentor);

                }
                return BadRequest("Login not possible");
            }
            catch (Exception)
            {
                return BadRequest("Login not possible");
            }
        }
        #endregion

        #region authenticate part
        private Mentor Authenticate(Login mentorlogin)
        {
            var m1 = _context.Mentors.FirstOrDefault(
                m=>m.EmailId==mentorlogin.Email && m.Password==mentorlogin.Password && m.JobRole==mentorlogin.Role);
            if (m1 != null)
            {
                return m1;
            }
            return null;
        }
        #endregion

        #region Generate token
        private string Generate(Mentor mentor)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,mentor.EmailId),
                new Claim(ClaimTypes.NameIdentifier,mentor.Password),
                new Claim(ClaimTypes.NameIdentifier,mentor.MentorName),
                new Claim(ClaimTypes.Role,mentor.JobRole)
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
