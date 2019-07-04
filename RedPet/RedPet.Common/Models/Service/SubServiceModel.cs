using System.Collections.Generic;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class SubServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
