using FCG.Domain.Entities.PaymentEntity;

namespace FCG.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment);
        Task<Payment?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
