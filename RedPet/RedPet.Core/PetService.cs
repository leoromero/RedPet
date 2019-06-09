﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Core.Base;
using RedPet.Database;
using RedPet.Database.Entities;
using RedPet.Database.Repositories;

namespace RedPet.Core
{
    public class PetService : CrudService<Pet, PetModel, PetCreateUpdateModel>, IPetService
    {
        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.GetRepository<IPetRepository>(), mapper)
        {
        }
    }

    public interface IPetService : ICrudService<Pet, PetModel, PetCreateUpdateModel>
    {
    }
}