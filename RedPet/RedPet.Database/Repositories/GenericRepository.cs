using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedPet.Database.Repositories
{
    public interface IRepository<T> where T : IBaseEntity
    {
        void Create(T entity);

        void CreateRange(IEnumerable<T> entity);

        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
    }

    public class GenericRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly RedPetContext _context;
        protected readonly DbSet<T> DbSet;

        protected GenericRepository(RedPetContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            DbSet.Add(entity);
        }

        public virtual void CreateRange(IEnumerable<T> entities)
        {
            var list = entities as IList<T> ?? entities.ToList();
            foreach (var entity in list)
                entity.CreatedDate = DateTime.Now;

            DbSet.AddRange(list);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await DbSet.Where(x => !x.InactivationDate.HasValue).ToListAsync();
        }
    }
}