using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class UnitSqlDAO : IUnitDAO
    {
        // PROPERTIES
        private readonly string connectionString;

        // CONSTRUCTORS
        public UnitSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // QUERIES
        private string sqlGetUnits =
            "SELECT unit_id, location_name, unit_number, unit_size, pictures_unitnumber, high_bid " +
            "FROM units;";

        //TODO: need to update for unit notes
        private string sqlPostUnit =
    "INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber) VALUES (@location_name, @unit_number, @unit_size, @pictures_unitnumber);";
        
        private string sqlPutUnit = "UPDATE units SET location_name = @location_name, unit_number = @unit_number, unit_size = @unit_size, pictures_unitnumber = @pictures_unitnumber WHERE unitId = @unitId;";

        // METHODS
        public List<Unit> GetUnits()
        {
            List<Unit> result = new List<Unit>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlGetUnits, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Unit unit = new Unit()
                    {
                        UnitId = Convert.ToInt32(reader["unit_id"]),
                        LocationName = Convert.ToString(reader["location_name"]),
                        UnitNumber = Convert.ToInt32(reader["unit_number"]),
                        UnitSize = Convert.ToString(reader["unit_size"]),
                        PicturesUnitNumber = Convert.ToInt32(reader["pictures_unitnumber"]),
                        HighBid = Convert.ToDecimal(reader["high_bid"]),
                    };

                    result.Add(unit);
                }

                return result;
            }
        }
        public Unit CreateNewUnit(string location_name, int unit_number, string unit_size, int pictures_unitnumber)
        {
            Unit result = new Unit();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlPostUnit, connection);

                command.Parameters.AddWithValue("@location_name", location_name);
                command.Parameters.AddWithValue("@unit_number", unit_number);
                command.Parameters.AddWithValue("@unit_size", unit_size);
                command.Parameters.AddWithValue("@pictures_unitnumber", pictures_unitnumber);
                command.ExecuteNonQuery();
            }
            return result;
        }
    }
}
