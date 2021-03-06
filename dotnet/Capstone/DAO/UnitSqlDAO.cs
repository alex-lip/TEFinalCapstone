﻿using Capstone.Models;
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
            //"SELECT unit_id, location_name, unit_number, unit_size, pictures, high_bid, unit_notes, facility_address " +
            //"FROM units;";
            "SELECT * FROM units;";

        private string sqlPostUnit =
            "INSERT INTO units (location_name, unit_number, unit_size, pictures, unit_notes, facility_address, high_bid, auction_end) " +
            "VALUES (@location_name, @unit_number, @unit_size, @pictures, @notes, @facility_address, @high_bid, @auction_end);";

        private string sqlPutUnit = 
            "UPDATE units SET location_name = @location_name, unit_number = @unit_number, unit_size = @unit_size, " +
            "pictures = @pictures, unit_notes = @notes, facility_address = @facility_address, " +
            "high_bid = @high_bid WHERE unit_id = @unitId;";
        
        private string sqlGetUnitById = 
            //"SELECT unit_id, location_name, unit_number, unit_size, pictures, high_bid " +
            //"FROM units WHERE unit_id = @unit_id";
            "SELECT * " +
            "FROM units " + 
            "WHERE unit_id = @unit_id;";

        private string sqlDeleteUnit = "DELETE FROM units WHERE unit_id = @unit_id";

        private string sqlGetBidInfo =
            //"SELECT bids.bid_id, bids.unit_id, bids.user_id, bids.bid_amount, bids.bid_placed, units.location_name, units.facility_address, users.username, units.unit_number, units.high_bid, units.auction_end" +
            "SELECT username" +
            "FROM bids" +
            "JOIN users ON users.user_id = bids.user_id " +
            "JOIN units ON units.unit_id = bids.unit_id " +
            "WHERE bids.unit_id = @unit_id AND bids.bid_amount = units.high_bid";

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
                        Pictures = Convert.ToString(reader["pictures"]),
                        HighBid = Convert.ToInt32(reader["high_bid"]),
                        Notes = Convert.ToString(reader["unit_notes"]),
                        FacilityAddress = Convert.ToString(reader["facility_address"]),
                        AuctionEnd = Convert.ToDateTime(reader["auction_end"])
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
                command.Parameters.AddWithValue("@pictures", unit.Pictures);
                command.Parameters.AddWithValue("@notes", unit.Notes);
                command.Parameters.AddWithValue("@facility_address", unit.FacilityAddress);
                command.Parameters.AddWithValue("@high_bid", (decimal)unit.HighBid);
                command.Parameters.AddWithValue("@auction_end", unit.AuctionEnd);
                command.ExecuteNonQuery();

                return true;
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
                        Pictures = Convert.ToString(reader["pictures"]),
                        HighBid = Convert.ToInt32(reader["high_bid"]),
                        Notes = Convert.ToString(reader["unit_notes"]),
                        FacilityAddress = Convert.ToString(reader["facility_address"]),
                        AuctionEnd = Convert.ToDateTime(reader["auction_end"])
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

        public bool EditUnit(int id, Unit unit)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlPutUnit, connection);
                command.Parameters.AddWithValue("@unitId", unit.UnitId);
                command.Parameters.AddWithValue("@location_name", unit.LocationName);
                command.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                command.Parameters.AddWithValue("@unit_size", unit.UnitSize);
                command.Parameters.AddWithValue("@pictures", unit.Pictures);
                command.Parameters.AddWithValue("@notes", unit.Notes);
                command.Parameters.AddWithValue("@facility_address", unit.FacilityAddress);
                command.Parameters.AddWithValue("@high_bid", (decimal)unit.HighBid);
                command.Parameters.AddWithValue("@end_date", unit.AuctionEnd);
                command.ExecuteNonQuery();

                return true;
            }
        }

        public string GetUnitBidInfo(int unitId)
        {
            string result = "";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlGetBidInfo, connection);
                command.Parameters.AddWithValue("@unit_id", unitId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string winnerEmail;
                    {
                        winnerEmail = Convert.ToString(reader["username"]);
                    };

                    result = winnerEmail;
                }

                return result;
        }
        }
    }
}
