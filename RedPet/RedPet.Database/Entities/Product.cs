using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
    }
}
