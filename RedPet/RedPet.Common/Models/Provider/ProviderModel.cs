using System.Collections.Generic;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Service;

namespace RedPet.Common.Models.Provider
{
    public class ProviderModel : IViewModel
    {
        public int Id { get; set; }
        public IList<ServiceModel> Services { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int IdentificationType { get; set; }
        public string Identification { get; set; }
        public string NationalityCode { get; set; }
        public string Address { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }

    public class ProviderCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public int IdType { get; set; }
        public string Identification { get; set; }
        public string NationalityCode { get; set; }
        public string Address { get; set; }
    }
}
