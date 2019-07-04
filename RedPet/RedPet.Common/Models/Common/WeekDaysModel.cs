using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Common
{
    public class WeekDaysModel : IViewModel, ICreateModel, IUpdateModel
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
