using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Capstone
{
    public class Email
    {

        public Email()
        {
        }

        public void EmailSend(string toEmail)
        {
            var fromAddress = new MailAddress("dotnetmike12@gmail.com", "Self Storage Auctions");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "dotnetmike";
            const string subject = "Welcome to Self Storage Auction";
            const string body = "Test Body Message";

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