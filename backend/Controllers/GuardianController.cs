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
        public GuardianController(IGuardianService guardianService)
        {
            _guardianService = guardianService;
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
        public async Task<ActionResult<GuardianDto>> AddGuardian(GuardianDto guardian)
        {
            Guardian guardianEntity = new Guardian();
            var addedGuardian = await _guardianService.AddGuardianAsync(guardian);
            return CreatedAtAction(nameof(GetGuardian), new { id = guardianEntity.GuardianId }, addedGuardian);
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