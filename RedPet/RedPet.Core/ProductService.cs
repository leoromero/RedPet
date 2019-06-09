using AutoMapper;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Product;

namespace RedPet.Core
{
    public class ProductService : CrudService<Product, ProductModel>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IProductRepository>(), mapper)
        {
        }
    }

    public interface IProductService : ICrudService<Product, ProductModel>
    {
    }
}