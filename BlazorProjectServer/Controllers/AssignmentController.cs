using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlazorProjectServer.Services;
using BlazorProjectServer.Models;
using System.Net;
using System.Threading.Tasks;

namespace BlazorProjectServer.Server.Controllers
{

    [Authorize]
    [Route("api/assignments")]
    public class AssignmentController : ControllerBase
    {
        private readonly IDatabaseService _dbService;

        public AssignmentController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            return Ok(await _dbService.GetAssignments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(await _dbService.GetAssignment(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            if (!await _dbService.IsExisctingAssignement(id))
            {
                return NotFound();
            }
            await _dbService.DeleteAssignment(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] Assignments assignments)
        {
            await _dbService.CreateAssignment(assignments);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAssignment([FromBody] Assignments assignment)
        {
            if (assignment == null)
            {
                return BadRequest();
            }
            await _dbService.EditAssignment(assignment);
            return NoContent();
        }
    }
}
