using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #region getall
        [HttpGet]
        //[Authorize (Roles ="Employee")]
        public async Task<IActionResult> GetAllEmplyoees()
        {
            try
            {
                var employees = await _employeeService.GetAll();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region getemployeesbymentorid
        [HttpGet("{MentorId:int}/mentorlist")]
        public async Task<IActionResult> GetByMentorId(int MentorId)
        {
            try
            {
                var employee = await _employeeService.GetByMentorId(MentorId);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        #endregion

        #region getbyid
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employee = await _employeeService.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region insert
        [HttpPost]
        public async Task<IActionResult> SaveRecord([Bind()] Employee entity)
        {
            try
            {
                await _employeeService.SaveRecord(entity);
                await _employeeService.Save();
                return (Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateRecord([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.UpdateRecord(employee);
                return (Ok(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
