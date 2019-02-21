using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime? InactivationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime? InactivationDate { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
