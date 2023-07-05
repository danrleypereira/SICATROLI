using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
namespace backend.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly MyDbContext _context;
        private readonly SignInManager<Guardian> _signInManager;
        private readonly IMapper _mapper;

        public GuardianService(DbContextOptions<MyDbContext> options)
        {
            _context = new MyDbContext(options);
        }
        private bool ValidateToken(string token)
        {
            Guardian user = _context.guardian.FirstOrDefault(u => u.Id == token);
            return user != null;
        }
        // public async Task<GuardianDto> LoginUserAsync(GuardianDto guardianDto, string token)
        // {
        //     bool isTokenValid = ValidateToken(token);
        //     var guardian = new Guardian();
        //     if (isTokenValid)
        //     {
        //         await _signInManager.SignInAsync(guardian, isPersistent: false);
        //     }
        //     return guardianDto;
        // }
        public async Task<GuardianResponseDto> AddGuardianAsync(CreateGuardianRequestDto guardianRequestDto, String moderator)
        {
            string token = TokenUtils.GenerateToken();

            Guardian GuardianEntity = _mapper.Map<Guardian>(guardianRequestDto);

            Institution institution = _context.Institutions.FirstOrDefault(e => e.ModeratorId == moderator);
            if(institution != null)
            {
                GuardianEntity.Id = token;
                GuardianEntity.Institution = institution;
                await _context.guardian.AddAsync(GuardianEntity);
                await _context.SaveChangesAsync();
            }
            var responseDto = _mapper.Map<GuardianResponseDto>(GuardianEntity);
            return responseDto;
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
        public async Task<IEnumerable<Guardian>> GetGuardiansAsync()
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
                if (!GuardianExists(guardian.Id))
                {
                    throw new ArgumentException($"Guardian with id {guardian.Id} not found.");
                }

                throw;
            }
            return guardian;
        }
        private bool GuardianExists(string id)
        {
            return _context.guardian.Any(e => e.Id == id);
        }
    }
}