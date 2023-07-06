using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;
using AutoMapper;
namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GuardianController(IGuardianService guardianService, IInstitutionService institutionService, IMapper mapper)
        {
            _guardianService = guardianService;
            _institutionService = institutionService;
            _mapper = mapper;
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
        public async Task<ActionResult<GuardianResponseDto>> AddGuardian(
            [FromBody] CreateGuardianRequestDto guardianRequestDto,
            [FromHeader] string authorization)
        {
            var authorization12 = Request.Headers.Authorization;
            if (! (await _institutionService.CheckModeratorToken(authorization)) )
            {
                return Unauthorized();
            }
            var addedGuardian = await _guardianService.AddGuardianAsync(guardianRequestDto, 
                authorization.Split(" ")[1]);
            return CreatedAtAction(nameof(GetGuardian), new { id = addedGuardian.Id }, addedGuardian);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Guardian>> UpdateGuardian(string id, Guardian guardian)
        {
            if (id != guardian.Id)
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