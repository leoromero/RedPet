using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class ServiceTypeModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
