using RedPet.Common.Models.Base;
using System;

namespace RedPet.Common.Models.Pet
{
    public class VaccineModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}