using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ComputerStore.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration Configuration;
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {

            //NetworkCredentials
            NetworkCredential networkCredential = new NetworkCredential
            {
                //not secure
                UserName = Configuration["EmailService:Smtp:Login"],
                Password = Configuration["EmailService:Smtp:Passw"]
            };

            // Mail message
            var _mailMessage = new MailMessage()
            {
                From = new MailAddress(networkCredential.UserName),
                Subject = subject,
                Body = message
            };

            _mailMessage.To.Add(email);


            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = networkCredential
            };

            // Send it...         

            return client.SendMailAsync(_mailMessage);


        }
    }
}
