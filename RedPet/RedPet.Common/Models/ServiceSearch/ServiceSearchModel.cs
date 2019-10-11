using System;

namespace RedPet.Common.Models.ServiceSearch
{
    public class ServiceSearchModel
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public int ServiceTypeId { get; set; }
        public int FrecuencyId { get; set; }
        public int PetSizeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Diameter { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
