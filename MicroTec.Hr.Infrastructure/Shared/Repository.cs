using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Infrastructure.Contexts;

namespace MicroTec.Hr.Infrastructure.Shared
{
    internal class Repository<TEntity>(ApplicationDbContext dbContext , IMapper mapper) : IRepository<TEntity> where TEntity :  BaseEntity 
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<TEntity?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>()
        .FirstOrDefaultAsync(e => e.Id == id && e.CreatedBy == userId && e.IsDeleted == false , cancellationToken);

        public async Task AddAsync(TEntity entity , CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().AddAsync(entity , cancellationToken);

        public void Update(TEntity entity)
            => _dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
        {
            // Soft delete by marking the entity as deleted
            var isDeletedProperty = entity.GetType().GetProperty("IsDeleted");
            isDeletedProperty?.SetValue(entity, true); // Set IsDeleted to true

            _dbContext.Set<TEntity>().Update(entity);
        }
        public async Task<PagedResult<TEntity>> GetPagedReadOnlyAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<TEntity>();

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<TEntity>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<TModel?> GetByIdReadOnlyAsync<TModel>(Guid id, Guid userId, CancellationToken cancellationToken) where TModel : BaseModel 
            => await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .Where(x => x.Id == id && x.CreatedBy == userId)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<TEntity?>> GetAllReadOnlyAsync(CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }
}
