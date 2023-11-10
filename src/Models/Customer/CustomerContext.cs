using Microsoft.EntityFrameworkCore;

namespace AlfarBackendChallengeV2.src.Models.Customer
{
    public class CustomerContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}