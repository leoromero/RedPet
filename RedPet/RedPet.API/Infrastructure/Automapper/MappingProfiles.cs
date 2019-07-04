﻿using AutoMapper;
using RedPet.Common.Models.Booking;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Product;
using RedPet.Common.Models.Promotion;
using RedPet.Common.Models.Provider;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.User;
using RedPet.Database.Entities;
using RedPet.Database.Entities.Identity;

namespace RedPet.API.Infrastructure.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.FacebookId, opts => opts.MapFrom(src => src.User.FacebookId))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.User.Gender))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName));
            CreateMap<CustomerModel, Customer>()
                .ForMember(x => x.User, opts => opts.Ignore());
            CreateMap<CustomerModel, User>();

            CreateMap<Provider, ProviderModel>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.FacebookId, opts => opts.MapFrom(src => src.User.FacebookId))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.User.Gender))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName));
            CreateMap<ProviderModel, Provider>()
                .ForMember(x => x.User, opts => opts.Ignore());
            CreateMap<ProviderModel, User>();

            CreateMap<CustomerCreateUpdateModel, Customer>().ReverseMap();
            CreateMap<ProviderCreateUpdateModel, Provider>()
                .ForMember(dest => dest.User, opts => opts.Ignore());
            CreateMap<CustomerCreateUpdateModel, User>().ReverseMap();
            CreateMap<ProviderCreateUpdateModel, User>().ReverseMap();
            CreateMap<UserCreateUpdateModel, CustomerCreateUpdateModel>().ReverseMap()
            .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName ?? src.Email));
            CreateMap<UserCreateUpdateModel, ProviderCreateUpdateModel>().ReverseMap()
            .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName ?? src.Email));

            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserCreateUpdateModel, User>().ReverseMap()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName ?? src.Email));

            CreateMap<Nationality, NationalityModel>().ReverseMap();
            CreateMap<IdentificationType, IdentificationTypeModel>().ReverseMap();

            CreateMap<Pet, PetModel>().ReverseMap();
            CreateMap<Pet, PetCreateUpdateModel>().ReverseMap();

            CreateMap<HairType, HairTypeModel>().ReverseMap();
            CreateMap<PetSize, PetSizeModel>().ReverseMap();
            CreateMap<WeightRange, WeightRangeModel>().ReverseMap();
            CreateMap<Breed, BreedModel>().ReverseMap();

            CreateMap<Booking, BookingModel>().ReverseMap();
            CreateMap<Booking, BookingCreateUpdateModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();

            CreateMap<ServiceType, ServiceTypeModel>().ReverseMap();

            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<Promotion, PromotionModel>().ReverseMap();
            CreateMap<PromotionProduct, PromotionProductModel>().ReverseMap();
            CreateMap<PromotionService, PromotionServiceModel>().ReverseMap();
            CreateMap<Audience, AudienceModel>().ReverseMap();

            CreateMap<Vaccine, VaccineModel>().ReverseMap();
            CreateMap<Vaccination, VaccinationModel>().ReverseMap();

            CreateMap<Vet, VetModel>().ReverseMap();

            CreateMap<Frecuency, FrecuencyModel>().ReverseMap();
        }
    }
}
