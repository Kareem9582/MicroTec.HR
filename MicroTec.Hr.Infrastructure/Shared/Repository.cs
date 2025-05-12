using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Infrastructure.Contexts;
using System.Linq;

namespace MicroTec.Hr.Infrastructure.Shared
{
    internal class Repository<TEntity>(ApplicationDbContext dbContext, IMapper mapper) : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<TEntity?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            // Apply includes (e.g., .Include(e => e.Custodies))
            if (include is not null)
            {
                query = include(query);
            }

            return await query
                .AsNoTracking() // optional: remove if tracking is needed
                .FirstOrDefaultAsync(e =>
                    e.Id == id &&
                    e.CreatedBy == userId &&
                    e.IsDeleted == false,
                    cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
            => await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        public void Update(TEntity entity)
            => _dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
        {
            // Soft delete by marking the entity as deleted
            var isDeletedProperty = entity.GetType().GetProperty("IsDeleted");
            isDeletedProperty?.SetValue(entity, true); // Set IsDeleted to true

            _dbContext.Set<TEntity>().Update(entity);
        }
        public async Task<PagedResult<TModel>> GetPagedReadOnlyAsync<TModel>(int pageNumber, int pageSize, string? searchTerm, Func<IQueryable<TEntity>, string?, IQueryable<TEntity>>? applySearch = null, CancellationToken cancellationToken = default) where TModel : BaseModel
        {
            var query = _dbContext
                .Set<TEntity>()
                .AsNoTracking();

            if (applySearch is not null)
                query = applySearch(query, searchTerm);

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResult<TModel>
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

        public async Task<IEnumerable<TEntity?>> Find(Func<IQueryable<TEntity>, IQueryable<TEntity>>? applySearch, CancellationToken cancellationToken)
        {
            var query = _dbContext
                .Set<TEntity>()
                .AsNoTracking();
            if (applySearch is not null)
                query = applySearch(query);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
