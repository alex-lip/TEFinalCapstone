using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        public int UnitId { get; set; }

        public int UserId { get; set; }

        public decimal BidAmount { get; set; }

        public DateTime BidPlaced { get; set; }
    }
}
