﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? InactivationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
