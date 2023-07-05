using AutoMapper;
using backend.Models;
namespace CleanArchMvc.Application.Mappings
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<Institution, InstitutionBodyDto>().ReverseMap();
            CreateMap<CreateGuardianRequestDto, Guardian>().ReverseMap();
            CreateMap<Guardian, GuardianResponseDto>().ReverseMap();
        }
    }
}