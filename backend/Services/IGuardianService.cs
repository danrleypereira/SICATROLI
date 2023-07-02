using backend.Models;
namespace backend.Services
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> GetGuardiansAsync();
        Task<Guardian> GetGuardianByIdAsync(string id);
        Task<Guardian> AddGuardianAsync(GuardianDto guardianDto, String moderator);
        Task<GuardianDto> LoginUserAsync(GuardianDto guardianDto, string token);
        Task<Guardian> UpdateGuardianAsync(Guardian guardian);
        Task DeleteGuardianAsync(string id);
    }
}