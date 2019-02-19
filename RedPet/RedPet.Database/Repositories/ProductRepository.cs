
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
    }
}
