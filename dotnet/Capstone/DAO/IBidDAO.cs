using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBidDAO
    {
       //TODO: fix syntax to accept methods below
        List<Bid> GetBids();

        /*Bid GetBidById(int bid_id);

        void DeleteBid(Bid bid);

        bool AddBid(Bid bid);

        bool EditBid(int id, Bid bid);
        */
    }
}
