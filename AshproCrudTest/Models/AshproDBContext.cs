using Microsoft.EntityFrameworkCore;

namespace AshproCrudTest.Models
{
    public class AshproDBContext :DbContext
    {
        public AshproDBContext(DbContextOptions<AshproDBContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
