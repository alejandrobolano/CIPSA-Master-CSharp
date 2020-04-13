using System;
using System.ComponentModel.DataAnnotations;
using VideoClub.Common.Enums;

namespace VideoClub.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        public int NumberDisc { get; set; }
        public StateProductEnum State { get; set; }

    }
}
