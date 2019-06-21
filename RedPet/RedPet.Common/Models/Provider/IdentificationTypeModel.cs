using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Provider
{
    public class IdentificationTypeModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
