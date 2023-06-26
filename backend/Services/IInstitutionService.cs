using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
    public interface IInstitutionService
    {
        Task<CreateInstitutionDto> CreateInstitutionAsync(CreateInstitutionDto institution);
        //starting examples
        Task<IEnumerable<Institution>> GetInstitutionsAsync();
        Task<Institution> GetInstitutionByIdAsync(int id);
        Task<Institution> UpdateInstitutionAsync(Institution institution);
        Task DeleteInstitutionAsync(int id);
        //ending examples
    }
}
