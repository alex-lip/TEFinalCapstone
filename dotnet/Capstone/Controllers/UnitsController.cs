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

        /*
        [HttpPost]
        public ActionResult<List<Unit>> CreateNewUnit()
        {
            
        }

        [HttpPut]
        public ActionResult<List<Unit>> EditUnit()
        {
            
        }

        [HttpDelete]
        public ActionResult<List<Unit>> DeleteUnit()
        {
            
        }
        */
    }
}
