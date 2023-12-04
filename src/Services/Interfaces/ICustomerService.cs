using AlfarBackendChallengeV2.src.Models.Customer;

namespace AlfarBackendChallengeV2.src.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> PostNewCustomer(Customer customer);

        Task<Customer> GetCustomer(int customerId);

        Task<Customer> UpdateCustomer(int customerId, Customer customer);

        Task DeleteCustomer(int customerId);
    }
}