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
        [HttpPost]
        public async Task<ActionResult<CreateInstitutionDto>> CreateInstitution(
            [FromHeader] String authorization, 
            [FromBody] CreateInstitutionDto institution
        )
        {
            if (!authorization.Contains("sdfgbhn"))
            {
                return Unauthorized();
            }
            Institution institutionEntity = new Institution();
            var addedInstitution = await _institutionService.CreateInstitutionAsync(institution);
            return CreatedAtAction(nameof(GetInstitution), new { id = institutionEntity.InstitutionId }, addedInstitution);
        }
        //starting examples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
        {
            var institutions = await _institutionService.GetInstitutionsAsync();
            return Ok(institutions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitution(int id)
        {
            var institution = await _institutionService.GetInstitutionByIdAsync(id);
            if (institution == null)
            {
                return NotFound();
            }
            return Ok(institution);
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
