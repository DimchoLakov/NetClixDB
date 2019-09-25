using System;
using System.Threading.Tasks;
using AspNetCore.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NetPhlixDB.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task<bool> SendEmailAsync(EmailDto input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SendEmailAsync(string recipient, string subject, string body)
        {
            var client = new SendGridClient(this.Options.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("support@netphlix.com", "Dimcho Lakov"),
                Subject = subject,
                PlainTextContent = body,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(recipient));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            try
            {
                await client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
