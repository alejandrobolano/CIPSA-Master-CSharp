using System;
using VideoClub.Common.Model.Enums;

namespace VideoClub.Common.Model.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int NumberDisc { get; set; }
        public StateProductEnum State { get; set; }
        public decimal Price { get; set; }

    }
}
