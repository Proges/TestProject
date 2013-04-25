using Shop.Business.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string userEmail, string title, string body)
        {
            string senderEmail = "testshopemail@gmail.com";
            string senderPassword = "ppppppppp1";

            NetworkCredential nc = new NetworkCredential(senderEmail, senderPassword);
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = nc;
            SmtpServer.EnableSsl = true;
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(userEmail);

            mail.Subject = title;
            mail.Body = body;
            SmtpServer.Send(mail);
        }
    }
}
