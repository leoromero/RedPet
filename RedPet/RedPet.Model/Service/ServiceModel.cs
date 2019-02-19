using System;
using RedPet.Model.Base;

namespace RedPet.Model.Service
{
    public class ServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
