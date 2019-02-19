using System;
using RedPet.Model.Base;

namespace RedPet.Model.Product
{
    public class ProductModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
