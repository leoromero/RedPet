
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IPromotionRepository : IRepository<Promotion>
    {
    }
}
