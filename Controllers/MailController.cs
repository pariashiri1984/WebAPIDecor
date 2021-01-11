using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using WebAPIDecor.Models;

namespace WebAPIDecor.Controllers
{
        public class Email {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        string adminEmail="paria.shiri20@gmail.com";
        string adminPassword="xxxxxxxx";

        //post api/Mail/SendEmail
        [HttpPost]
        public IActionResult SendEmail(Email email) {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("DecorAdmin", adminEmail);
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User",email.To);
            message.To.Add(to);
            message.Subject =email.Subject;
            BodyBuilder body = new BodyBuilder();
            body.HtmlBody = email.Body;
            message.Body = body.ToMessageBody();
            
            SmtpClient client = new SmtpClient();

            //client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            client.Authenticate(adminEmail, adminPassword);
        
            try {

                client.Send(message);

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return NotFound();
            }

            client.Disconnect(true);
            client.Dispose();
            return Ok();
        }

    

    }
}
