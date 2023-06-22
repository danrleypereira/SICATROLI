using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
    public interface IInstitutionService
    {
        Task<IEnumerable<Institution>> GetInstitutionsAsync();
        Task<Institution> GetInstitutionByIdAsync(int id);
        Task<InstitutionDto> AddInstitutionAsync(InstitutionDto institution);
        Task<Institution> UpdateInstitutionAsync(Institution institution);
        Task DeleteInstitutionAsync(int id);
    }
}
