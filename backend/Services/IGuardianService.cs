using backend.Models;
namespace backend.Services
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> GetGuardiansAsync();
        Task<Guardian> GetGuardianByIdAsync(string id);
        Task<GuardianResponseDto> AddGuardianAsync(Guardian guardian, String moderator);
        //Task<GuardianDto> LoginUserAsync(GuardianDto guardianDto, string token);
        Task<Guardian> UpdateGuardianAsync(Guardian guardian);
        Task DeleteGuardianAsync(string id);
    }
}