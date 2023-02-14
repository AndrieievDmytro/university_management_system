using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlazorProjectServer.Services;
using BlazorProjectServer.Models;
using System.Net;
using System.Threading.Tasks;

namespace BlazorProjectServer.Server.Controllers
{

    [Authorize]
    [Route("api/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly IDatabaseService _dbService;

        public SubjectController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            return Ok(await _dbService.GetSubjects());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(await _dbService.GetSubject(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!await _dbService.IsExisctingSubject(id))
            {
                return NotFound();
            }
            await _dbService.DeleteSubject(id);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            await _dbService.CreateSubject(subject);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubject([FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }
            await _dbService.EditSubject(subject);
            return NoContent();
        }
    }
}
