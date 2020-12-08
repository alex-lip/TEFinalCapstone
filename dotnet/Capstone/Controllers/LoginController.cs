﻿using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDAO userDAO;

        System.Random random = new System.Random();

       
        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, IUserDAO _userDAO)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            userDAO = _userDAO;
        }

        /// <summary>
        /// A test endpoint to ensure that the server is running.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("ready")]
        public string Ready()
        {
            return "Server Ready";
        }

        /// <summary>
        /// A test endpoint requiring authorization to ensure that authorization is working.
        /// </summary>
        [Authorize]
        [HttpGet("confirm")]
        public string Confirm()
        {
            return "Token confirmed";
        }

        /// <summary>
        /// A test endpoint requiring authorization and the role of 'admin' to ensure that authorization is working.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpGet("confirmadmin")]
        public string ConfirmAdmin()
        {
            return "Token confirmed for admin";
        }

        /// <summary>
        /// Authenticates the user and returns a result including their authenticated token
        /// </summary>
        /// <param name="userParam">The login request</param>
        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDAO.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                LoginResponse retUser = new LoginResponse()
                {
                    User = new ReturnUser()
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Role = user.Role
                    },
                    Token = token
                };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userParam">The new user to create</param>
        [HttpPost("register")]
        public IActionResult Register(RegisterUser userParam)
        {
            IActionResult result;

            int sixDigitNumber = random.Next(100000, 999999);
            Email email = new Email();
            email.EmailSend(userParam.Username, sixDigitNumber);
            


            User existingUser = userDAO.GetUser(userParam.Username);
            if (existingUser != null)
            {
                return Conflict(new { message = "Username already taken. Please choose a different username." });
            }

            User user = userDAO.AddUser(userParam.Username, userParam.Password, userParam.Role, sixDigitNumber);
            if (user != null)
            {
                result = Created(user.Username, null);
                userDAO.AddVerificationCode(user, sixDigitNumber);

            }
            else
            {
                result = BadRequest(new { message = "An error occurred and user was not created." });
            }

            return result;
        }

        // Verify method
        // User enters a 6 digit number into a new page that is the redirect from /register
        // This verify method checks the entered number against the generated number, which has been added to that user record in DB
        // If the numbers match, change that field to "EMAIL_VERIFIED", which allows them to login

        // Front End
        // View for registration/verify

    }
}
