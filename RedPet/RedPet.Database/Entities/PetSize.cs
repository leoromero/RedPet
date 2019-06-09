namespace RedPet.Database.Entities
{
    public class PetSize : BaseEntity
    {
        public string Name { get; set; }

        public int? WeightRangeId { get; set; }

        public virtual WeightRange WeightRange { get; set; }
    }
}
