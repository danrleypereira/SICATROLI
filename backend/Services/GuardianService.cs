using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly MyDbContext _context;

        public GuardianService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<GuardianDto> AddGuardianAsync(GuardianDto guardianDto)
        {
            string token = TokenUtils.GenerateToken();
            Guardian GuardianEntity = new Guardian
            {
                GuardianId = token,
                BookId = guardianDto.BookId,
                Email = guardianDto.email,
                
            };
            await _context.Guardians.AddAsync(GuardianEntity);
            await _context.SaveChangesAsync();

            return guardianDto;
        }

        public Task DeleteGuardianAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Guardian> GetGuardianByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guardian>> GetGuardiansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guardian> UpdateGuardianAsync(Guardian guardian)
        {
            throw new NotImplementedException();
        }
    }
}