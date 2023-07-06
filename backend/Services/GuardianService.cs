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

        public GuardianService(DbContextOptions<MyDbContext> options, IMapper mapper)
        {
            _context = new MyDbContext(options);
            _mapper = mapper;
        }
        private bool ValidateToken(string token)
        {
            Guardian user = _context.guardians.FirstOrDefault(u => u.Id == token);
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
        public async Task<GuardianResponseDto> AddGuardianAsync(CreateGuardianRequestDto guardianRequestDto, String moderatorId)
        {
            string token = TokenUtils.GenerateToken();

            Guardian GuardianEntity = _mapper.Map<Guardian>(guardianRequestDto);

            Institution institution = _context.Institutions.FirstOrDefault(e => e.ModeratorId == moderatorId);
            if(institution != null)
            {
                GuardianEntity.Id = token;
                GuardianEntity.Institution = institution;
                await _context.guardians.AddAsync(GuardianEntity);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<GuardianResponseDto>(GuardianEntity);
        }
        public async Task DeleteGuardianAsync(string id)
        {
            var Guardian = await _context.guardians.FindAsync(id);
            if (Guardian == null)
            {
                throw new ArgumentException($"Guardian with id {id} not found.");
            }
            _context.guardians.Remove(Guardian);
            await _context.SaveChangesAsync();
        }
        public async Task<Guardian> GetGuardianByIdAsync(string id)
        {
            return await _context.guardians.FindAsync(id);
        }
        public async Task<IEnumerable<Guardian>> GetGuardiansAsync()
        {
            return await _context.guardians.ToListAsync();
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
            return _context.guardians.Any(e => e.Id == id);
        }
    }
}