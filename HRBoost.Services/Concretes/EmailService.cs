using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class EmailService: IEmailService
    {
        public async Task SendEmail(string receptor,string subject,string body)
        {
            var email = Environment.GetEnvironmentVariable("EMAIL_ADRESS");
            var password = Environment.GetEnvironmentVariable("EMAIL_PASS");
            var host = "smtp.gmail.com";
            var port = 587;

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

             smtpClient.Credentials = new NetworkCredential(email, password);

            var message = new MailMessage(email!,receptor,subject,body);
            await smtpClient.SendMailAsync(message);
        }
    }
}
