namespace MicroTec.Hr.Domain.Contract
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
