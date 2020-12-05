using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class UnitSqlDAO
    {
        private readonly string connectionString;

        // QUERIES
        private string sqlGetUnits =
            "SELECT unit_id, location_name, unit_number, unit_size, pictures_unitnumber, high_bid " +
            "FROM units;";
    }
}
