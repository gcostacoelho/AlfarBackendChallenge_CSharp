using System.Net;
using AlfarBackendChallengeV2.src.Data;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Models.Utils;
using AlfarBackendChallengeV2.src.Services.Interfaces;

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
            try
            {
                _appDbContext.Add(customer);

                await _appDbContext.SaveChangesAsync();

                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Internal Server Error");
            }
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _appDbContext.Customers.FindAsync(customerId);

            if (customer == null)
            {
                throw new ApiException("Customer not found", HttpStatusCode.NoContent);
            }

            return customer;
        }


        public async Task<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            _appDbContext.Entry(customer).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customerToDelete = await _appDbContext.Customers.FindAsync(customerId);

            if (customerToDelete == null)
            {
                throw new ApiException("Customer not found", HttpStatusCode.NoContent);
            }

            _appDbContext.Customers.Remove(customerToDelete);

            await _appDbContext.SaveChangesAsync();
        }
    }
}