using System;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Product;
using RedPet.Common.Models.Promotion;
using RedPet.Common.Models.Service;
using RedPet.Common.Models.User;

namespace RedPet.Common.Models.Booking
{
    public class BookingModel : IViewModel
    {
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int Id { get; set; }

        public ServiceModel Service { get; set; }
        public ProductModel Product { get; set; }
        public PromotionModel Promotion { get; set; }
        public CustomerModel Customer { get; set; }
        public PetModel Pet { get; set; }
        public StateModel State { get; set; }
    }

    public class BookingCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDateTime { get; set; }

        public int CustomerId { get; set; }
        public int? PetId { get; set; }
        public int? ServiceId { get; set; }
        public int? ProductId { get; set; }
        public int? PromotionId { get; set; }
    }

}
