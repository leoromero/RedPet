using System;
using System.Collections.Generic;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Common;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Provider;

namespace RedPet.Common.Models.Service
{
    public class ServiceModel : IViewModel
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public int ProviderId { get; set; }
        public int WeekDaysId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public ProviderModel Provider { get; set; }
        public WeekDaysModel WeekDays { get; set; }
        public ServiceTypeModel ServiceType { get; set; }
        
        public virtual IList<PetSizeModel> PetSizes { get; set; }
        public virtual IList<FrecuencyModel> Frecuencies { get; set; }
        public virtual IList<SubServiceModel> SubServices { get; set; }
    }

    public class ServiceCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ServiceTypeId { get; set; }
        public int UserId { get; set; }

        public WeekDaysModel WeekDays { get; set; }
        public IList<int> Frecuencies { get; set; }
        public IList<int> PetSizes { get; set; }
        public IList<int> ServiceSubTypes { get; set; }
    }
}
