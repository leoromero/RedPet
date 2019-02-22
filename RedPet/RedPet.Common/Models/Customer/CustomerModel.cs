using System.Collections.Generic;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;

namespace RedPet.Common.Models.User
{
    public class CustomerModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PetModel> Pets { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}
