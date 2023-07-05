using AutoMapper;
using backend.Models;
namespace CleanArchMvc.Application.Mappings
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<Institution, InstitutionBodyDto>().ReverseMap();
            CreateMap<CreateGuardianRequestDto, Guardian>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => TokenUtils.GenerateToken())).ReverseMap();
            CreateMap<Guardian, GuardianResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => TokenUtils.GenerateToken())).ReverseMap();
        }
    }
}