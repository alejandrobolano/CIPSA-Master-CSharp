using VideoClub.Common.Model.Enums;

namespace VideoClub.Common.BusinessLogic.Dto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int NumberDisc { get; set; }
        public StateProductEnum State { get; set; }
        public decimal Price { get; set; }

    }
}
