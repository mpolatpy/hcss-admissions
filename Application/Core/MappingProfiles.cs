using Application.Students;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.PrimaryParent, o => o.MapFrom(
                    s => s.Parents.FirstOrDefault(x => x.IsPrimaryParent == true).Parent.LastFirst))
                .ForMember(d => d.SecondaryParent, o => o.MapFrom(
                    s => s.Parents.FirstOrDefault(x => x.IsPrimaryParent == false).Parent.LastFirst));
        }
    }
}