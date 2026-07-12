using FCG.Domain.Entities.GameEntity;
using FCG.Domain.Repositories;
using FCG.Infrastructure.Data;

namespace FCG.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly CatalogDbContext _context;

        public GameRepository(CatalogDbContext context) => _context = context;

        public async Task AddAsync(Game game) => await _context.Games.AddAsync(game);

        public async Task<Game?> GetByIdAsync(Guid id) => await _context.Games.FindAsync(id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
