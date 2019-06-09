
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class WeightRangeRepository : GenericRepository<WeightRange>, IWeightRangeRepository
    {
        public WeightRangeRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IWeightRangeRepository : IRepository<WeightRange>
    {
    }
}
