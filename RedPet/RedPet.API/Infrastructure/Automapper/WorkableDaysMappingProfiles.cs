using AutoMapper;
using RedPet.Common.Models.Common;
using RedPet.Database.Entities;
using System;

namespace RedPet.API.Infrastructure.Automapper
{
    public class WeekDaysMappingProfiles : Profile
    {
        public WeekDaysMappingProfiles()
        {
            CreateMap<WeekDays, WeekDaysModel>().ReverseMap()
                .ForMember(dest => dest.CreatedDate, opts => opts.MapFrom(x => DateTime.Now));
        }
    }
}
