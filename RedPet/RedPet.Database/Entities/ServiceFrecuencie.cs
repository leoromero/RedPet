namespace RedPet.Database.Entities
{
    public class ServiceFrecuency : BaseEntity
    {
        public int ServicePriceId { get; set; }
        public int FrecuencyId { get; set; }

        public virtual Frecuency Frecuency { get; set; }
        public virtual Service Service { get; set; }
    }
}