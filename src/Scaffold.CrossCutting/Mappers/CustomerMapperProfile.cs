using AutoMapper;
using Scaffold.Domain.Entities;
using Scaffold.Infrastructure.Models;

namespace Scaffold.CrossCutting.Mappers
{
    public class CustomerMapperProfile : Profile
    {

        public CustomerMapperProfile()
        {

            CreateMap<Customer, CustomerModelDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Document, opt => opt.MapFrom(src => src.Document));
        }
    }
}
