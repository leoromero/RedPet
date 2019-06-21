using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class ServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public int? PetSizeId { get; set; }
    }
}
