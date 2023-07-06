using backend.Models;
namespace backend.Services
{
    public interface IInstitutionService
    {
        Task<InstitutionBodyDto> CreateInstitutionAsync(InstitutionDtoRequestBody institution);
        //starting examples
        Task<IEnumerable<Institution>> GetInstitutionsAsync();
        Task<InstitutionBodyDto> GetInstitutionByIdAsync(String moderatorId);
        Task<bool> CheckModeratorToken(string id);
        Task<Institution> UpdateInstitutionAsync(Institution institution);
        Task DeleteInstitutionAsync(int id);
        //ending examples
    }
}
