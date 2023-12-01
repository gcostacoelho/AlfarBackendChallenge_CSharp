using MimeKit;
using MailKit.Net.Smtp;

using AlfarBackendChallengeV2.src.Models.Email;
using AlfarBackendChallengeV2.src.Services.Interfaces;
using AlfarBackendChallengeV2.src.Models;
using Microsoft.Extensions.Options;

namespace AlfarBackendChallengeV2.src.Services.MailKitService
{
    public class MailKitService : IMailKitService
    {
        private readonly IOptions<AppSettings> _appSettings;

        public MailKitService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Send email with data from Customer
        /// </summary>
        /// <param name="emailInformations">Informations to send a email</param>
        public void SendEmail(Email emailInformations)
        {
            try
            {
                var smtpInformations = _appSettings.Value.AppSettingsConf;

                var email = new MimeMessage();
                var smtp = new SmtpClient();

                email.From.Add(new MailboxAddress(smtpInformations.SmtpUsername, smtpInformations.SmtpEmail));
                email.To.Add(new MailboxAddress(emailInformations.Username, emailInformations.To));

                email.Subject = emailInformations.Subject;

                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = emailInformations.Body
                };

                smtp.Connect("smtp.gmail.com", 587, false);

                smtp.Authenticate(smtpInformations.SmtpUsername, smtpInformations.SmtpPassword);

                smtp.Send(email);

                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Internal Server Error");
            }
        }
    }
}