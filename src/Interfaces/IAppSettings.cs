namespace AlfarBackendChallengeV2.src.Interfaces
{
    public interface IAppSettings
    {
        public string SmtpEmail { get; }
        public string SmtpUsername { get; }
        public string SmtpPassword { get; }
    }
}