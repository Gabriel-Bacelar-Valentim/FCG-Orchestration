using FCG.Domain.Entities.PaymentEntity;
using FCG.Domain.Repositories;
using FCG.Infrastructure.Data;

namespace FCG.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context) => _context = context;

        public async Task AddAsync(Payment payment) => await _context.Payments.AddAsync(payment);

        public async Task<Payment?> GetByIdAsync(Guid id) => await _context.Payments.FindAsync(id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
