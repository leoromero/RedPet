namespace RedPet.Database.Entities
{
    public class Audience : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual PetSize PetSize { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual WeightRange WeightRange { get; set; }

        public int? PetSizeId { get; set; }
        public int? BreedId { get; set; }
        public int? WeightRangeId { get; set; }
    }
}
