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
    "INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber, unit_notes, facility_address, high_bid) " +
            "VALUES (@location_name, @unit_number, @unit_size, @pictures_unitnumber, @notes, @facility_address, @high_bid);";

        private string sqlPutUnit = "UPDATE units SET location_name = @location_name, unit_number = @unit_number, unit_size = @unit_size, pictures_unitnumber = @pictures_unitnumber, unit_notes = @notes, facility_address = @facility_address, high_bid = @high_bid WHERE unitId = @unitId;";

        private string sqlGetUnitById = "SELECT unit_id, location_name, unit_number, unit_size, pictures_unitnumber, high_bid " +
            "FROM units WHERE unit_id = @unit_id";

        private string sqlDeleteUnit = "DELETE FROM units WHERE unit_id = @unit_id";


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
                        HighBid = Convert.ToInt32(reader["high_bid"]),
                    };

                    result.Add(unit);
                }

                return result;
            }
        }

        public bool AddUnit(Unit unit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlPostUnit, connection);
                command.Parameters.AddWithValue("@location_name", unit.LocationName);
                command.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                command.Parameters.AddWithValue("@unit_size", unit.UnitSize);
                command.Parameters.AddWithValue("@pictures_unitnumber", unit.PicturesUnitNumber);
                command.Parameters.AddWithValue("@notes", unit.Notes);
                command.Parameters.AddWithValue("@facility_address", unit.FacilityAddress);
                command.Parameters.AddWithValue("@high_bid", (decimal)unit.HighBid);
                //command.Parameters.AddWithValue("@end_date", unit.AuctionEnd);
                command.ExecuteNonQuery();

                return true;

                //@location_name, @unit_number, @unit_size, @pictures_unitnumber, @notes, @facility_address

            }
        }

        public Unit GetUnitById(int unit_id)
        {
            Unit result = new Unit();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlGetUnitById, connection);
                command.Parameters.AddWithValue("@unit_id", unit_id);

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
                        HighBid = Convert.ToInt32(reader["high_bid"]),
                    };
                    result = unit;
                }

                return result;
            }
        }

        public void DeleteUnit(Unit unit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlDeleteUnit, connection);
                command.Parameters.AddWithValue("@unit_id", unit.UnitId);
                command.ExecuteNonQuery();
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

        public bool EditUnit(int id, Unit unit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlPutUnit, connection);
                command.Parameters.AddWithValue("@location_name", unit.LocationName);
                command.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                command.Parameters.AddWithValue("@unit_size", unit.UnitSize);
                command.Parameters.AddWithValue("@pictures_unitnumber", unit.PicturesUnitNumber);
                command.Parameters.AddWithValue("@notes", unit.Notes);
                command.Parameters.AddWithValue("@facility_address", unit.FacilityAddress);
                command.Parameters.AddWithValue("@high_bid", (decimal)unit.HighBid);
                command.Parameters.AddWithValue("@end_date", unit.AuctionEnd);
                command.ExecuteNonQuery();

                return true;
            }
        }
    }
}
