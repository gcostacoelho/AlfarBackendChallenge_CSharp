using AlfarBackendChallengeV2.src.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace AlfarBackendChallengeV2.src.Facades.Interfaces
{
    public interface ICustomerFacade
    {
        Task<Customer> PostNewCustomerAndSendEmailAsync(Customer customer);
    }
}