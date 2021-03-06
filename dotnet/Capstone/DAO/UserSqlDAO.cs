﻿using System;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        private string sqlGetUser = "SELECT user_id, username, password_hash, salt, user_role, verification_status FROM users WHERE username = @username";
        private string sqlAddUser = "INSERT INTO users (username, password_hash, salt, user_role) VALUES " +
            "(@username, @password_hash, @salt, @user_role)";
        // Insert code in DB
        private string sqlAddVerificationCode = "INSERT INTO verification_code (user_id, code) VALUES (@user_id, @code); SELECT SCOPE_IDENTITY()";
        private string sqlGetVerificationCode = "SELECT code FROM verification_code WHERE user_id = (SELECT user_id FROM users WHERE users.username = '@username')";
        private string sqlChangeVerifiedStatus = "UPDATE users SET verification_status = @verification_status " +
            "WHERE user_id = (SELECT user_id FROM users WHERE users.username = @username)";


        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnUser = GetUserFromReader(reader);
                }
            }

            return returnUser;
        }


        public User AddUser(string username, string password, string role, int verificationCode)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                cmd.Parameters.AddWithValue("@salt", hash.Salt);
                cmd.Parameters.AddWithValue("@user_role", role);
                cmd.ExecuteNonQuery();
            }

            return GetUser(username);
        }

        public void AddVerificationCode(User user, int verificationCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddVerificationCode, conn);
                cmd.Parameters.AddWithValue("@user_id", user.UserId);
                cmd.Parameters.AddWithValue("@code", verificationCode);
                cmd.ExecuteNonQuery();
            }
        }

        public void ChangeVerifiedStatus(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                int verifiedStatus = 1;

                SqlCommand cmd = new SqlCommand(sqlChangeVerifiedStatus, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@verification_status", verifiedStatus);
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckVerificationCode(string username, int userInputVerificationCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetVerificationCode, conn);
                cmd.Parameters.AddWithValue("@username", username);

                int returnValue = cmd.ExecuteNonQuery();

                if (returnValue != userInputVerificationCode)
                {
                    
                    return true;
                    
                }
            }

            return false;
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
                VerificationStatus = Convert.ToInt32(reader["verification_status"])
            };

            return u;
        }
    }
}
