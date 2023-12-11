using AlfarBackendChallengeV2.src.Models.Email;

namespace AlfarBackendChallengeV2.src.Services.Interfaces
{
    public interface IMailKitService
    {
        void SendEmail(Email emailInformations);
    }
}