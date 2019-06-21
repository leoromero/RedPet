using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Provider
{
    public class NationalityModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Nation { get; set; }
        public string Code { get; set; }
    }
}
