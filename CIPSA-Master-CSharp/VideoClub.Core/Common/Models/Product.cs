using System;
using VideoClub.Core.Common.Enums;

namespace VideoClub.Core.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberDisc { get; set; }
        public StateProductEnum State { get; set; }

    }
}
