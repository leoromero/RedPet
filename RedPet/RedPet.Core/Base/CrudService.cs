using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;
using RedPet.Common.Models.Base;

namespace RedPet.Core.Base
{
    public abstract class CrudService<T, TViewModel, TCreateModel, TUpdateModel> : BaseService, ICrudService<T, TViewModel, TCreateModel, TUpdateModel>
        where T : class, IBaseEntity
        where TViewModel : IViewModel
        where TCreateModel : ICreateModel
        where TUpdateModel : IUpdateModel
    {
        protected readonly IRepository<T> Repository;

        protected CrudService(IUnitOfWork unitOfWork, IRepository<T> repository, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            Repository = repository;
        }
        public virtual async Task<EntityResult<List<TViewModel>>> GetAsync()
        {
            var result = new EntityResult<List<TViewModel>>();
            var entities = await Repository.GetAsync();
            result.Entity = Mapper.Map<List<TViewModel>>(entities);
            return result;
        }

        public virtual async Task<EntityResult<TViewModel>> GetAsync(int id)
        {
            var result = new EntityResult<TViewModel>();
            var entity = await Repository.GetAsync(id);
            result.Entity = Mapper.Map<TViewModel>(entity);
            return result;
        }

        public virtual async Task<EntityResult<int>> CreateAsync(TCreateModel model)
        {
            var result = new EntityResult<int>();
            var entity = Mapper.Map<T>(model);
            Repository.Create(entity);
            await UnitOfWork.Complete();
            result.Entity = entity.Id;
            return result;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Repository.GetAsync(id);
            entity.InactivationDate = DateTime.Now;
            await UnitOfWork.Complete();
        }

        public virtual async Task UpdateAsync(int id, TUpdateModel model)
        {
            var entity = await Repository.GetAsync(id);

            Mapper.Map(model, entity);

            await UnitOfWork.Complete();
        }
    }

    public interface ICrudService<T, TViewModel, in TCreateModel, in TUpdateModel>
    {
        Task<EntityResult<List<TViewModel>>> GetAsync();
        Task<EntityResult<TViewModel>> GetAsync(int id);
        Task<EntityResult<int>> CreateAsync(TCreateModel model);
        Task UpdateAsync(int id, TUpdateModel model);
        Task DeleteAsync(int id);
    }
}