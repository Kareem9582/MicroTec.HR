using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IReadOnlyRepository<TEntity> ReadOnlyRepository<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
