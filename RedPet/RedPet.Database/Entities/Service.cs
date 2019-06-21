﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public int ServiceTypeId { get; set; }
        public int? PetSizeId { get; set; }
        public int ProviderId { get; set; }

        public virtual ServiceType Type { get; set; }
        public virtual PetSize PetSize { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
