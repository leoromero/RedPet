using System.Collections.Generic;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Service;

namespace RedPet.Common.Models.Provider
{
    public class ProviderModel : IViewModel
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public IdentificationTypeModel IdentificationType { get; set; } = new IdentificationTypeModel();
        public string Identification { get; set; } = string.Empty;
        public NationalityModel Nationality { get; set; } = new NationalityModel(); 
        public string Address { get; set; } = string.Empty;

        public string Name => $"{FirstName} {LastName}";
    }

    public class ProviderCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public int? IdentificationTypeId { get; set; }
        public string Identification { get; set; }
        public int? NationalityId { get; set; }
        public string Address { get; set; }
    }
}
