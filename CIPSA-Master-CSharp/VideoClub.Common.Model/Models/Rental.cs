using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Common.Model.Models
{
    public class Rental
    {
        public Product Product { get; set; }
        public Client Client { get; set; }
        public DateTime StartRental { get; set; }

        public DateTime FinishRental { get; set; }
    }
}
