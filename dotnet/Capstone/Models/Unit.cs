using System;

namespace Capstone.Models
{
    public class Unit
    {
        public int UnitId { get; set; }

        public string LocationName { get; set; }

        public int UnitNumber { get; set; }

        public string UnitSize { get; set; }

        public int PicturesUnitNumber { get; set; }

        public int HighBid { get; set; }

        public string Notes { get; set; }

        public string FacilityAddress { get; set; }

        public DateTime AuctionEnd { get; set; }
    }
}
