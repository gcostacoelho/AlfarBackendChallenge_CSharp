using AlfarBackendChallengeV2.src.Data;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _appDbContext.Customers.FindAsync(customerId);

            return customer;
        }


        public async Task<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            _appDbContext.Entry(customer).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return customer;
        }

        public Task<IActionResult> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

    }
}