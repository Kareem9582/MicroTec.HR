using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id , CancellationToken cancellationToken);
        Task<IEnumerable<TLookup>> GetAllAsync<TLookup>(CancellationToken cancellationToken) where TLookup : BaseLookup;
    }
}
