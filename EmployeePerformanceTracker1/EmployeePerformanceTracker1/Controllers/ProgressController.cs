using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : Controller
    {
        public readonly ProgressService _progressService;

        public ProgressController(ProgressService progressService)
        {
            _progressService = progressService;
        }

        #region insert
        [HttpPost]
        public async Task<IActionResult> SaveRecord([Bind()] Progress entity)
        {
            try
            {
                await _progressService.SaveProgressDescription(entity);
                await _progressService.Save();
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
        public async Task<IActionResult> UpdateRecord([FromBody] Progress progress)
        {
            try
            {
                await _progressService.UpdateProgressDescription(progress);
                return (Ok(progress));
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
                var progress = await _progressService.GetById(id);
                if (progress == null)
                {
                    return NotFound();
                }
                return Ok(progress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region getprogressbyemployeeid
        [HttpGet("{employeeId:int}/progressList")]
        public async Task<IActionResult> GetByEmployeeId(int employeeId)
        {
            try
            {
                var progress = await _progressService.GetByEmployeeId(employeeId);
                if (progress == null)
                {
                    return NotFound();
                }
                return Ok(progress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}
