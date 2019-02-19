using System.Collections.Generic;
using RedPet.Model.Base;
using RedPet.Model.Pet;

namespace RedPet.Model.User
{
    public class UserModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public IList<PetModel> Pets { get; set; }
    }
}
