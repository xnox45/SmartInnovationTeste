using AutoMapper;
using Infra.DTOs;
using Infra.Entities;

namespace Infra.ConfigurationInjector
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<Person, PersonDTO>();
        }
    }
}
