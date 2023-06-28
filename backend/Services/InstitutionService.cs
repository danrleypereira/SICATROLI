using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly MyDbContext _context;

        public InstitutionService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<CreateInstitutionDto> CreateInstitutionAsync(CreateInstitutionDto institution)
        {
            string token = TokenUtils.GenerateToken();
            Institution institutionEntity = new Institution
            {
                guardians = null,
                Name = institution.Name,
                Telephone = institution.Telephone,
                ModeratorId = token
            };
            await _context.Institutions.AddAsync(institutionEntity);
            await _context.SaveChangesAsync();

            return institution;
        }

        //starting examples
        public async Task<IEnumerable<Institution>> GetInstitutionsAsync()
        {
            return await _context.Institutions.ToListAsync();
        }

        public async Task<Institution> GetInstitutionByIdAsync(int id)
        {
            return await _context.Institutions.FindAsync(id);
        }
        public async Task<Institution> UpdateInstitutionAsync(Institution institution)
        {
            _context.Entry(institution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(institution.InstitutionId))
                {
                    throw new ArgumentException($"Institution with id {institution.InstitutionId} not found.");
                }

                throw;
            }

            return institution;
        }

        public async Task DeleteInstitutionAsync(int id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                throw new ArgumentException($"Institution with id {id} not found.");
            }

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();
        }

        private bool InstitutionExists(int id)
        {
            return _context.Institutions.Any(e => e.InstitutionId == id);
        }
        //ending examples
    }
}
