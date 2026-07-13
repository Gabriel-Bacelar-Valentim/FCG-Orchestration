using FCG.Domain.Entities.GameEntity;
using FCG.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GameMapping());
        }
    }
}
