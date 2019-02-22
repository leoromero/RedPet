using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class ServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
    }
}
