using AlfarBackendChallengeV2.src.Interfaces;

namespace AlfarBackendChallengeV2.src.Models.Utils
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;

        public AppSettings(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string SmtpEmail => _config["AppSettings:SmtpEmail"];

        public string SmtpUsername => _config["AppSettings:SmtpUsername"];

        public string SmtpPassword => _config["AppSettings:SmtpPassword"];
    }
}