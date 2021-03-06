﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BidSqlDAO : IBidDAO
    {
        // PROPERTIES
        private readonly string connectionString;

        // CONSTRUCTORS
        public BidSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // QUERIES
        //"SELECT * " +
        private string sqlGetBids =
            "SELECT b.bid_id, n.location_name, n.facility_address, n.unit_number, b.bid_amount, b.bid_placed, u.username, n.unit_id, u.user_id, n.high_bid, n.auction_end " +
            "FROM bids b " +
            "JOIN users u ON u.user_id = b.user_id " +
            "JOIN units n ON n.unit_id = b.unit_id;";

        private string sqlPostBid =
            "INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) " +
            "VALUES (@unit_id, @user_id, @bid_amount, @bid_placed);";

        //private string sqlGetBidById =
        //    "SELECT b.bid_id, n.location_name, n.facility_address, n.unit_number, b.bid_amount, b.bid_placed, n.auction_end, u.username " +
        //    "FROM bids b " +
        //    "JOIN users u ON u.user_id = b.user_id " +
        //    "JOIN units n ON n.unit_id = b.unit_id " +
        //    "WHERE bid_id = @bid_id;";

        //private string sqlGetBidByUnitId =
        //    "SELECT b.bid_id, n.location_name, n.facility_address, n.unit_number, b.bid_amount, b.bid_placed, n.auction_end, u.username" +
        //    "FROM bids b " +
        //    "JOIN users u ON u.user_id = b.user_id " +
        //    "JOIN units n ON n.unit_id = b.unit_id " +
        //    "FROM bids WHERE unit_id = @unit_id;";

        private string sqlGetBidByUserId =
            "SELECT b.bid_id, n.location_name, n.facility_address, n.unit_number, b.bid_amount, b.bid_placed, n.auction_end, u.username " +
            "FROM bids b " +
            "JOIN users u ON u.user_id = b.user_id " +
            "JOIN units n ON n.unit_id = b.unit_id " +
            "FROM bids WHERE user_id = @user_id;";

        //TODO: Finish methods below
        // METHODS
        public List<Bid> GetBids()
        {
            List<Bid> result = new List<Bid>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlGetBids, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bid bid = new Bid()
                    {
                        BidId = Convert.ToInt32(reader["bid_id"]),
                        UnitId = Convert.ToInt32(reader["unit_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        BidAmount = Convert.ToDecimal(reader["bid_amount"]),
                        BidPlaced = Convert.ToDateTime(reader["bid_placed"]),
                        LocationName = Convert.ToString(reader["location_name"]),
                        FacilityAddress = Convert.ToString(reader["facility_address"]),
                        Username = Convert.ToString(reader["username"]),
                        UnitNumber = Convert.ToInt32(reader["unit_number"]),
                        HighBid = Convert.ToDecimal(reader["high_bid"]),
                        AuctionEnd = Convert.ToDateTime(reader["auction_end"]),
                    };

                    result.Add(bid);
                }

                return result;
            }
        }

        public bool AddBid(Bid bid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlPostBid, connection);
                command.Parameters.AddWithValue("@unit_id", bid.UnitId);
                command.Parameters.AddWithValue("@user_id", bid.UserId);
                command.Parameters.AddWithValue("@bid_amount", bid.BidAmount);
                command.Parameters.AddWithValue("@bid_placed", bid.BidPlaced);
                command.ExecuteNonQuery();

                return true;

            }
        }

        /*
        public Bid GetUnitById(int bid_id)
        {
            Bid result = new Bid();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlGetBidById, connection);
                command.Parameters.AddWithValue("@bid_id", bid_id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bid bid = new Bid()
                    {
                        BidId = Convert.ToInt32(reader["bid_id"]),
                        UnitId = Convert.ToInt32(reader["unit_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        BidAmount = Convert.ToInt32(reader["bid_amount"]),//TODO: Is there a decimal converter? Is that even necessary
                        BidPlaced = Convert.ToString(reader["bid_placed"])//TODO: Is there a datetime converter?
                    };
                    result = bid;
                }

                return result;
            }
        }
       
        */
    }
}
