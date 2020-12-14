using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    // "Route" & "ApiController" use AspNetCore.Mvc
    [Route("[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        // PROPERTIES
        private readonly IBidDAO bidDAO;

        // CONSTRUCTORS
        public BidsController(IBidDAO bidDAO)
        {
            this.bidDAO = bidDAO;
        }
        
        // CONTROLLER METHODS
        [HttpGet]
        public ActionResult<List<Bid>> GetAllBids()
        {
            return Ok(bidDAO.GetBids());
        }

        
        [HttpPost]
        public ActionResult CreateBid(Bid bid)
        {
            return Ok(bidDAO.AddBid(bid));
        }
        /*
        [HttpPut("{id}")]
        public ActionResult EditBid(int id, Bid bid)
        {
            return Ok(bidDAO.EditBid(id, bid));
        }

        [HttpDelete("{bidId}")]
        public ActionResult DeleteBid(int bidId)
        {
            Bid bid = this.bidDAO.GetBidById(bidId);

            if (bid == null || bidId == 0)
            {
                return NotFound();
            }

            this.bidDAO.DeleteBid(bid);

            return NoContent();

        }
        */
    }
}
