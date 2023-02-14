using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlazorProjectServer.Services;
using BlazorProjectServer.Models;
using System.Net;
using System.Threading.Tasks;

namespace BlazorProjectServer.Server.Controllers
{

    [Authorize]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly IDatabaseService _dbService;

        public CourseController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _dbService.GetCourses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok( await _dbService.GetCourse(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!await _dbService.IsExisctingCourse(id))
            {
                return NotFound();
            }
            await _dbService.DeleteCourse(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _dbService.CreateCourse(course);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            await _dbService.EditCourse(course);
            return NoContent();
        }

    }
}
