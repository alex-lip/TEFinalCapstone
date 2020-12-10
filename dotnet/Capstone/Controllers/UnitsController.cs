using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    // "Route" & "ApiController" use AspNetCore.Mvc
    [Route("[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        // PROPERTIES
        private readonly IUnitDAO unitDAO;

        // CONSTRUCTORS
        public UnitsController(IUnitDAO unitDAO)
        {
            this.unitDAO = unitDAO;
        }

        // CONTROLLER METHODS
        [HttpGet]
        public ActionResult<List<Unit>> GetAllUnits()
        {
            return Ok(unitDAO.GetUnits());
        }

        
        //[HttpPost]
        //public IActionResult CreateNewUnit(Unit newUnit)
        //{
        //    RestRequest request = new RestRequest(this.API_URL + "units");
            
        //    request.AddJsonBody(newUnit);
            
        //    IRestResponse<Unit> response = this.client.Post<Unit>(request);
            
        //    if(response.ResponseStatus != ResponseStatus.Completed)
        //    {
        //        Console.WriteLine("Could not add the specified unit");
        //        return null;
        //    }

        //    if(!response.IsSuccessful)
        //    {
        //        Console.WriteLine();
        //        return null;
        //    }

        //    return response.Data;
        //}
        
        //[HttpPut]
        //public Unit EditUnit(Unit updatedUnit)
        //{
        //    RestRequest request = new RestRequest(this.API_URL + "units/" + updatedUnit.Id);

        //    request.AddJsonBody(updatedUnit);

        //    IRestResponse<Unit> response = this.client.Put<Unit>(request);

        //    if (response.ResponseStatus != ResponseStatus.Completed)
        //    {
        //        Console.WriteLine("Could not update the specified unit");
        //        return null;
        //    }

        //    if (!response.IsSuccessful)
        //    {
        //        Console.WriteLine("Encountered an error updating unit: " + response.ErrorMessage + " (" + response.StatusCode + ")");
        //        return null;
        //    }

        //    return response.Data;
        //}

        //[HttpDelete]
        //public bool DeleteUnit(int unitId)
        //{
        //     RestRequest request = new RestRequest(this.API_URL + "units/" + unitId);

        //    IRestResponse response = this.client.Delete(request);

        //    if (response.ResponseStatus != ResponseStatus.Completed)
        //    {
        //        Console.WriteLine("Could not delete the specified unit");
        //        return false;
        //    }

        //    if (!response.IsSuccessful)
        //    {
        //        Console.WriteLine("Encountered an error deleting unit: " + response.ErrorMessage + " (" + response.StatusCode + ")");
        //        return false;
        //    }

        //    return true;
        //}
        
    }
}
