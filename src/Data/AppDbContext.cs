using AlfarBackendChallengeV2.src.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace AlfarBackendChallengeV2.src.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(connectionString: "Server=172.17.0.2,1433;Database=alfarBackend;TrustServerCertificate=True;User ID=sa;Password=1q2w3e4r@#$");
    }
}