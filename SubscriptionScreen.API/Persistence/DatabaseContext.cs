using Microsoft.EntityFrameworkCore;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() 
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=pg2024;Host=localhost;Port=5432;Database=SubscriptionTable;");
            }
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
