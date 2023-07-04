using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpGet("getByModeratorId")]
        public async Task<ActionResult<InstitutionBodyDto>> GetInstitution([FromQuery] String moderatorId)
        {
            var institution = await _institutionService.GetInstitutionByIdAsync(moderatorId);
            if (institution == null)
            {
                return NotFound();
            }
            return Ok(institution);
        }

        [HttpPost]
        public async Task<ActionResult<InstitutionDtoRequestBody>> CreateInstitution(
            [FromHeader] String authorization,
            [FromBody] InstitutionDtoRequestBody institution
        )
        {
            if (!authorization.Contains("sdfgbhn"))
            {
                return Unauthorized();
            }
            InstitutionBodyDto addedInstitution = await _institutionService.CreateInstitutionAsync(institution);
            return CreatedAtAction(nameof(GetInstitution), new {moderatorId = addedInstitution.ModeratorId }, addedInstitution);
        }

        //starting examples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
        {
            var institutions = await _institutionService.GetInstitutionsAsync();
            return Ok(institutions);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Institution>> UpdateInstitution(int id, Institution institution)
        {
            if (id != institution.InstitutionId)
            {
                return BadRequest();
            }

            var updatedInstitution = await _institutionService.UpdateInstitutionAsync(institution);
            if (updatedInstitution == null)
            {
                return NotFound();
            }

            return Ok(updatedInstitution);
        }
        //ending examples
    }
}
