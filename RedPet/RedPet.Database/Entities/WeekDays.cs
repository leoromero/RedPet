﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class WeekDays : BaseEntity
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
