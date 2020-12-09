using System;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        private string sqlGetUser = "SELECT user_id, username, password_hash, salt, user_role FROM users WHERE username = @username";
        private string sqlAddUser = "INSERT INTO users (username, password_hash, salt, user_role) VALUES " +
            "(@username, @password_hash, @salt, @user_role)";
        // Insert code in DB
        private string sqlAddVerificationCode = "INSERT INTO verification_code (user_id, code) VALUES (@user_id, @code); SELECT SCOPE_IDENTITY()";
        private string sqlGetVerificationCode = "SELECT code FROM verification_code WHERE user_id = @user_id";

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

        public bool CheckVerificationCode(User user, int userInputVerificationCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetVerificationCode, conn);
                cmd.Parameters.AddWithValue("@user_id", user.UserId);

                int returnValue = cmd.ExecuteNonQuery();

                if (returnValue != userInputVerificationCode)
                {
                    Console.WriteLine("It works");
                      
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
            };

            return u;
        }
    }
}
