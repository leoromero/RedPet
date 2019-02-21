using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class ServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
