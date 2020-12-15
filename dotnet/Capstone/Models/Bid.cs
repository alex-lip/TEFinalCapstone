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

        public string LocationName { get; set; }

        public string FacilityAddress { get; set; }

        public string Username { get; set; }

        public int UnitNumber { get; set; }

        public decimal HighBid { get; set; }

        public DateTime AuctionEnd { get; set; }
    }
}
