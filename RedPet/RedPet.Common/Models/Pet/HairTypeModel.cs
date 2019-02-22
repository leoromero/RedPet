using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Pet
{
    public class HairTypeModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public int? Id { get; set; }
    }
}