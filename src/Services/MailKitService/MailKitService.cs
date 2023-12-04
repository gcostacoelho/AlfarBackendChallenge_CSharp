using MimeKit;
using MailKit.Net.Smtp;

using AlfarBackendChallengeV2.src.Interfaces;
using AlfarBackendChallengeV2.src.Models.Email;
using AlfarBackendChallengeV2.src.Services.Interfaces;

namespace AlfarBackendChallengeV2.src.Services.MailKitService
{
    public class MailKitService : IMailKitService
    {
        private readonly IAppSettings _appSettings;

        public MailKitService(IAppSettings appSettings)
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

                var email = new MimeMessage();
                var smtp = new SmtpClient();

                email.From.Add(new MailboxAddress(_appSettings.SmtpUsername, _appSettings.SmtpEmail));
                email.To.Add(new MailboxAddress(emailInformations.Username, emailInformations.To));

                email.Subject = emailInformations.Subject;

                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = emailInformations.Body
                };

                smtp.Connect("smtp.gmail.com", 587, false);

                smtp.Authenticate(_appSettings.SmtpUsername, _appSettings.SmtpPassword);

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