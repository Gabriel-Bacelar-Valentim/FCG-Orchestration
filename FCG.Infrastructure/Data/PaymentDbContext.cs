using FCG.Domain.Entities.PaymentEntity;
using FCG.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentMapping());
        }
    }
}
