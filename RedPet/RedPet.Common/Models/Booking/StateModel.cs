using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Booking
{
    public class StateModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
