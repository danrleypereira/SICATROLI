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
            if (! (await _institutionService.CheckModeratorToken(authorization)) )
            {
                return Unauthorized();
            }
            var guardian = _mapper.Map<Guardian>(guardianRequestDto);
            var addedGuardian = await _guardianService.AddGuardianAsync(guardian, authorization.Split(" ")[1]);
            var responseDto = _mapper.Map<GuardianResponseDto>(addedGuardian);
            return CreatedAtAction(nameof(GetGuardian), new { id = addedGuardian.GuardianId }, responseDto);
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