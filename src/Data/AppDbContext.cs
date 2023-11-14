using AlfarBackendChallengeV2.src.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace AlfarBackendChallengeV2.src.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet <Customer> Customers { get; set; }
    }
}