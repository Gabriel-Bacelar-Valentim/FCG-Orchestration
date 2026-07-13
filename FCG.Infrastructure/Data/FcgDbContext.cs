using FCG.Domain.Entities.UserEntity;
using FCG.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data
{
    public class FcgDbContext : DbContext
    {
        public FcgDbContext(DbContextOptions<FcgDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}