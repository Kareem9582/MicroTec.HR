using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
        Task<TModel?> GetByIdReadOnlyAsync<TModel>(Guid id, Guid userId, CancellationToken cancellationToken) where TModel : BaseModel;
        Task<IEnumerable<TEntity?>> GetAllReadOnlyAsync(CancellationToken cancellationToken);
        Task<IEnumerable<TEntity?>> Find(Func<IQueryable<TEntity>, IQueryable<TEntity>>? applySearch,CancellationToken cancellationToken);
        Task<PagedResult<TModel>> GetPagedReadOnlyAsync<TModel>(int pageNumber, int pageSize, string? searchTerm, Func<IQueryable<TEntity>, string?, IQueryable<TEntity>>? applySearch = null, CancellationToken cancellationToken = default) where TModel : BaseModel;
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
