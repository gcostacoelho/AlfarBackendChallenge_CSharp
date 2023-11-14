using AlfarBackendChallengeV2.src.Data;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Services.Interfaces;

namespace AlfarBackendChallengeV2.src.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _appDbContext;

        public CustomerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Customer> PostNewCustomer(Customer customer)
        {
            _appDbContext.Add(customer);

            await _appDbContext.SaveChangesAsync();

            return customer;
        }
    }
}