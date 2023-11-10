namespace AlfarBackendChallengeV2.src.Models.Customer
{
    public class Customer
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
    }
}