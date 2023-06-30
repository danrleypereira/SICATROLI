using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;
namespace backend.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly MyDbContext _context;
        private readonly UserManager<Guardian> _userManager;
        private readonly SignInManager<Guardian> _signInManager;
        public GuardianService(DbContextOptions<MyDbContext> options)
        {
            _context = new MyDbContext(options);
        }
        private bool ValidateToken(string token)
        {
            var user =  _context.guardian.FirstOrDefault(u => u.GuardianId == token);
            return user != null;
        }
        public async Task<GuardianDto> LoginUserAsync(GuardianDto guardianDto, string token)
        {
            bool isTokenValid = ValidateToken(token);
            var guardian = new Guardian();
            if (isTokenValid)
            {
                await _signInManager.SignInAsync(guardian, isPersistent: false);
            }
            return guardianDto;
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
            await _context.guardian.AddAsync(GuardianEntity);
            await _context.SaveChangesAsync();
            return guardianDto;
        }

        public async Task DeleteGuardianAsync(string id)
        {
            var Guardian = await _context.guardian.FindAsync(id);
            if (Guardian == null)
            {
                throw new ArgumentException($"Guardian with id {id} not found.");
            }

            _context.guardian.Remove(Guardian);
            await _context.SaveChangesAsync();
        }

        public async Task<Guardian> GetGuardianByIdAsync(string id)
        {
            return await _context.guardian.FindAsync(id);
        }

        public  async Task<IEnumerable<Guardian>> GetGuardiansAsync()
        {
            return await _context.guardian.ToListAsync();
        }

        public async Task<Guardian> UpdateGuardianAsync(Guardian guardian)
        {
            _context.Entry(guardian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuardianExists(guardian.GuardianId))
                {
                    throw new ArgumentException($"Guardian with id {guardian.GuardianId} not found.");
                }

                throw;
            }

            return guardian;
        }
        private bool GuardianExists(string id)
        {
            return _context.guardian.Any(e => e.GuardianId == id);
        }

    }
}