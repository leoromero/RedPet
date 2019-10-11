using AutoMapper;
using RedPet.Common.Models.Service;
using RedPet.Database.Entities;
using System;
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
                .ForMember(dest => dest.ServiceFrecuencies, opts => opts.MapFrom(src => src.Frecuencies.Select(f => new ServiceFrecuency { FrecuencyId = f.Id, CreatedDate = DateTime.Now })))
                .ForMember(dest => dest.ServicePetSizes, opts => opts.MapFrom(src => src.PetSizes.Select(ps => new ServicePetSize { PetSizeId = ps.Id.Value, CreatedDate = DateTime.Now })))
                .ForMember(dest => dest.ServiceSubServices, opts => opts.MapFrom(src => src.ServiceSubTypes.Select(s => new ServiceSubService { ServiceSubTypeId = s.Id, CreatedDate = DateTime.Now })))
                .ForMember(dest => dest.ProviderId, opts => opts.Ignore())
                .AfterMap((src, dest) =>
                {
                    foreach (var item in dest.ServicePetSizes)
                    {
                        item.ServiceId = dest.Id;
                    }
                });
        }
    }
}
