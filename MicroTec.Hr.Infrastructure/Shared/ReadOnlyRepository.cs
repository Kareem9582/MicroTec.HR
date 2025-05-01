using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Infrastructure.Contexts;

namespace MicroTec.Hr.Infrastructure.Shared
{
    internal class ReadOnlyRepository<TEntity>(ApplicationDbContext dbContext) : IReadOnlyRepository<TEntity> where TEntity : class , IEntity
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<TEntity?> GetByIdAsync(Guid id)
            => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbContext.Set<TEntity>().ToListAsync();
    }
}
