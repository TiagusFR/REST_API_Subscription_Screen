using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubscriptionScreen.API.Entities;

namespace SubscriptionScreen.API.Data
{
    public class SubscriptionScreenAPIContext : DbContext
    {
        public SubscriptionScreenAPIContext (DbContextOptions<SubscriptionScreenAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SubscriptionScreen.API.Entities.User> User { get; set; } = default!;
    }
}
