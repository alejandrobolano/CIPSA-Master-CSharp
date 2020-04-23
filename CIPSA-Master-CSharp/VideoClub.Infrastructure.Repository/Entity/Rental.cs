using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoClub.Common.Model.Utils;
using VideoClub.Infrastructure.Repository.Contracts;

namespace VideoClub.Infrastructure.Repository.Entity
{
    public class Rental : IEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public DateTime StartRental { get; set; }
        [Required]
        public DateTime FinishRental { get; set; }

        public Rental()
        {
            var random = new Random();
            Id = Helper.GetCodeNumber(Helper.Rental, 6, random);
        }
    
    }
}
