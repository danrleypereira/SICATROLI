using AutoMapper;
using backend.Models;

namespace CleanArchMvc.Application.Mappings
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<Institution, CreateInstitutionDto>().ReverseMap();
            CreateMap<CreateGuardianRequestDto, Guardian>().ReverseMap();
            CreateMap<Guardian, GuardianResponseDto>()
            .ForMember(dest => dest.GuardianId, opt => opt.MapFrom(src => TokenUtils.GenerateToken())).ReverseMap();
        }
    }
}

