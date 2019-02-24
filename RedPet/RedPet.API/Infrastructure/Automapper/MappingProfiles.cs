﻿using AutoMapper;
using RedPet.Common.Models.Booking;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Product;
using RedPet.Common.Models.Promotion;
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
                .ForMember(x => x.User, opts => opts.MapFrom(src => new User()
                {
                    Email = src.Email,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    FacebookId = src.FacebookId,
                    UserName = src.UserName,
                    Gender = src.Gender
                }));

            CreateMap<Pet, PetModel>().ReverseMap();
            CreateMap<Pet, PetCreateUpdateModel>().ReverseMap();
            CreateMap<HairType, HairTypeModel>().ReverseMap();
            CreateMap<PetSize, PetSizeModel>().ReverseMap();
            CreateMap<WeightRange, WeightRangeModel>().ReverseMap();
            CreateMap<Breed, BreedModel>().ReverseMap();

            CreateMap<Booking, BookingModel>().ReverseMap();
            CreateMap<Booking, BookingCreateUpdateModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();

            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<Promotion, PromotionModel>().ReverseMap();
            CreateMap<PromotionProduct, PromotionProductModel>().ReverseMap();
            CreateMap<PromotionService, PromotionServiceModel>().ReverseMap();
            CreateMap<Audience, AudienceModel>().ReverseMap();
        }
    }
}
