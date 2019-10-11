using RedPet.Common.Models.Common;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Common.Models.ServiceSearch
{
    public class ServiceSearchResultModel
    {
        public UserModel Provider { get; set; }
        public decimal TotalPrice { get; set; }
        public int FrecuencyId { get; set; }
        public int PetSizeID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public WeekDaysModel WeekDays { get; set; }
        public List<PriceDetailModel> PriceDetail { get; set; }
    }
}
