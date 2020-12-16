using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;

namespace Capstone
{
    public class Email
    {

        public Email()
        {
        }

        

        public void EmailSend(string toEmail, int verificationNumber)
        {
            
            var fromAddress = new MailAddress("dotnetmike12@gmail.com", "Self Storage Auctions");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "dotnetmike";
            const string subject = "Welcome to Self Storage Auction";
            string body = "Enter the following code on the site to verify your account: " + verificationNumber;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }

        public void EmailWinner(string toEmail, int unitId)
        {

            var fromAddress = new MailAddress("dotnetmike12@gmail.com", "Self Storage Auctions");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "dotnetmike";
            const string subject = "Self Storage Auctions";
            string body = "You won the Auction!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };



            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }

    }
}