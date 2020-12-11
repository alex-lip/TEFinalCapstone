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

        [HttpPost]
        public ActionResult CreateUnit(Unit unit)
        {
            return Ok(unitDAO.AddUnit(unit));
        }

        [HttpDelete("{unitId}")]
        public ActionResult DeleteUnit(int unitId)
        {
            Unit unit = this.unitDAO.GetUnitById(unitId);

            if (unit == null || unitId == 0)
            {
                return NotFound();
            }

            this.unitDAO.DeleteUnit(unit);

            return NoContent();

        }

    }
}
