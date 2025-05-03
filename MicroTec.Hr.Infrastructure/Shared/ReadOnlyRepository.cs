using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Infrastructure.Contexts;

namespace MicroTec.Hr.Infrastructure.Shared
{
    internal class ReadOnlyRepository<TEntity>(ApplicationDbContext dbContext, IMapper mapper) : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);

        public async Task<IEnumerable<TLookup>> GetAllAsync<TLookup>(CancellationToken cancellationToken) where TLookup : BaseLookup
         => await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ProjectTo<TLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
