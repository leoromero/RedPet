using RedPet.Common.Models.Service;

namespace RedPet.Common.Models.ServiceSearch
{
    public class PriceDetailModel
    {
        public ServiceModel Service { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}