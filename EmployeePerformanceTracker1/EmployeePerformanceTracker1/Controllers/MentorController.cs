using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Services;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : Controller
    {
        
        public readonly MentorService _mentorService;
        public MentorController(MentorService mentorService)
        {
            _mentorService = mentorService;
        }
        #region getbyid
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mentorService.GetMentorDetailsById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Mentor entity)
        {
            await _mentorService.UpdateMentorDetails(entity);
            await _mentorService.Save();
            return Ok(entity);
        }
        #endregion
    }
}

