using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IInstitutionService _institutionService;
        public GuardianController(IGuardianService guardianService, IInstitutionService institutionService)
        {
            _guardianService = guardianService;
            _institutionService = institutionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guardian>> GetGuardian(string id)
        {
            var guardian = await _guardianService.GetGuardianByIdAsync(id);
            if (guardian == null)
            {
                return NotFound();
            }
            return Ok(guardian);
        }
        [HttpPost]
        public async Task<ActionResult<Guardian>> AddGuardian(
                [FromBody] GuardianDto guardian,
                [FromHeader] string authorization)
        {
            if (! (await _institutionService.CheckModeratorToken(authorization)) )
            {
                return Unauthorized();
            }
            var addedGuardian = await _guardianService.AddGuardianAsync(guardian, authorization.Split(" ")[1]);
            return CreatedAtAction(nameof(GetGuardian), new { id = addedGuardian.GuardianId }, addedGuardian);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Guardian>> UpdateGuardian(string id, Guardian guardian)
        {
            if (id != guardian.GuardianId)
            {
                return BadRequest();
            }

            var updatedGuardian = await _guardianService.UpdateGuardianAsync(guardian);
            if (updatedGuardian == null)
            {
                return NotFound();
            }

            return Ok(updatedGuardian);
        }
    }
}