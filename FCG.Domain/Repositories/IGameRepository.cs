using FCG.Domain.Entities.GameEntity;

namespace FCG.Domain.Repositories
{
    public interface IGameRepository
    {
        Task AddAsync(Game game);
        Task<Game?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
