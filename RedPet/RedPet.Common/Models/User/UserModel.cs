using RedPet.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Common.Models.User
{
    public class UserModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }
}
