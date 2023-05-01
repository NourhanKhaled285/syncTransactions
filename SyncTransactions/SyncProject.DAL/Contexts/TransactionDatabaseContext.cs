using Microsoft.EntityFrameworkCore;

namespace SyncProject.DAL
{
    public class TransactionDatabaseContext:DbContext
    {
        public TransactionDatabaseContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Transaction> Transactions { get; set;}
        public DbSet<Category> Categories { get; set; }
    }
}
