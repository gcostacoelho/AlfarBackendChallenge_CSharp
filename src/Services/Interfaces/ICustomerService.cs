using AlfarBackendChallengeV2.src.Models.Customer;

namespace AlfarBackendChallengeV2.src.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> PostNewCustomer(Customer customer);
    }
}