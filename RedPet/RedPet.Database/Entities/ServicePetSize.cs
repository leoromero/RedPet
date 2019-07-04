namespace RedPet.Database.Entities
{
    public class ServicePetSize : BaseEntity
    {
        public int ServicePriceId { get; set; }
        public int PetSizeId { get; set; }

        public virtual PetSize PetSize { get; set; }
        public virtual Service Service { get; set; }
    }
}