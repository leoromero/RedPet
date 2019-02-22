using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Product
{
    public class ProductModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
