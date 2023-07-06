using AutoMapper;
using backend.Models;
namespace backend.Mappings
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<Institution, InstitutionBodyDto>().ReverseMap();
            CreateMap<Institution, InstitutionDtoRequestBody>().ReverseMap();
            CreateMap<Guardian, CreateGuardianRequestDto>().ReverseMap();
            CreateMap<Guardian, GuardianResponseDto>().ReverseMap();
        }
    }
}