using KairaCQRSMediator.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KairaCQRSMediator.DataAccess.Context
{
    public class KairaContext : DbContext
    {
        public KairaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

    }
}
