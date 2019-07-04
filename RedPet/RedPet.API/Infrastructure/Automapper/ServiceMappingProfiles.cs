using AutoMapper;
using RedPet.Common.Models.Service;
using RedPet.Database.Entities;
using System.Linq;

namespace RedPet.API.Infrastructure.Automapper
{
    public class ServiceMappingProfiles : Profile
    {
        public ServiceMappingProfiles()
        {
            CreateMap<ServiceModel, Service>().ReverseMap()
                 .ForMember(dest => dest.SubServices, opts => opts.MapFrom(src => src.ServiceSubServices.Select(ps => ps.ServiceSubType).ToList()))
                 .ForMember(dest => dest.Frecuencies, opts => opts.MapFrom(src => src.ServiceFrecuencies.Select(ps => ps.Frecuency).ToList()))
                .ForMember(dest => dest.PetSizes, opts => opts.MapFrom(src => src.ServicePetSizes.Select(ps => ps.PetSize).ToList()));

            CreateMap<ServiceCreateUpdateModel, Service>()
                .ForMember(dest => dest.ProviderId, opts => opts.Ignore());
        }
    }
}
