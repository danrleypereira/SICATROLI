using backend.Models;

namespace backend.Services
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> GetGuardiansAsync();
        Task<Guardian> GetGuardianByIdAsync(int id);
        Task<GuardianDto> AddGuardianAsync(GuardianDto guardianDto);
        Task<Guardian> UpdateGuardianAsync(Guardian guardian);
        Task DeleteGuardianAsync(int id);
    }
}