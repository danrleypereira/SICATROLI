using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<ActionResult<Institution>> AddInstitution(Institution institution)
        {
            var addedInstitution = await _institutionService.AddInstitutionAsync(institution);
            return CreatedAtAction(nameof(GetInstitution), new { id = addedInstitution.InstitutionId }, addedInstitution);
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
    }
}
