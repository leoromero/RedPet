namespace RedPet.Database.Entities
{
    public class ServiceSubService : BaseEntity
    {
        public int ServiceId { get; set; }
        public int ServiceSubTypeId { get; set; }

        public virtual SubService ServiceSubType { get; set; }
        public virtual Service Service { get; set; }
    }
}
