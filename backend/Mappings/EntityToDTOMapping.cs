using AutoMapper;
using backend.Models;

namespace CleanArchMvc.Application.Mappings
{
    public class EntityToDTOMapping : Profile 
    {
        public EntityToDTOMapping()
        {
            CreateMap<Institution, CreateInstitutionDto>().ReverseMap();
        }
    }
}

