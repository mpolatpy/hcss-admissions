using Application.Applications;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Application, Domain.Application>();
            CreateMap<ApplicationDto, Domain.Application>();
            CreateMap<ApplicationDto, Student>();
        }
    }
}