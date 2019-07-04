using System.Collections.Generic;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Service
{
    public class FrecuencyModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
