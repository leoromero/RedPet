using RedPet.Common.Models.Base;
using System;

namespace RedPet.Common.Models.Pet
{
    public class VetModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}