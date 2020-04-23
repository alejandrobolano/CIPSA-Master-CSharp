using System;

namespace VideoClub.Common.BusinessLogic.Dto
{
    public class RentalDto
    {
        public ProductDto ProductDto { get; set; }
        public ClientDto ClientDto { get; set; }
        public DateTime StartRental { get; set; }

        public DateTime FinishRental { get; set; }
    }
}
