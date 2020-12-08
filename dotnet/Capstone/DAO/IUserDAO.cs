using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role, int verificationCode);
        void AddVerificationCode(User user, int verificationCode);
    }
}
