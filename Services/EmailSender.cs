using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CytonInterview.Controllers.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {

            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string htmlContent)
        {
            //try
            //{
            //    string toEmail = string.IsNullOrEmpty(email)
            //                     ? _emailSettings.ToEmail
            //                     : email;
            //    MailMessage mail = new MailMessage()
            //    {
            //        From = new MailAddress(_emailSettings.UsernameEmail, "Emmanuel Ogoma")
            //    };
            //    mail.To.Add(new MailAddress(toEmail));
            //    //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

            //    mail.Subject = subject;
            //    mail.Body ="Thanks for registering with us, to corfirm your registration, please click on this link"+message;
            //    mail.IsBodyHtml = false;
            //    mail.Priority = MailPriority.High;

            //    using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.SecondaryPort))
            //    {
            //        smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
            //        smtp.EnableSsl = true;
            //        smtp.UseDefaultCredentials = false;
            //         smtp.Send(mail);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //do something here
            //}

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("support@citoninterview.net","Emmanuel Ogoma");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            return SendEmailAsync(email, "Registration On Cyton Rider Services", callbackUrl);
        }
    }
}
