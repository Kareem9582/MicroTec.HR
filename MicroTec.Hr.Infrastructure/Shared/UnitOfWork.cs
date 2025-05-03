using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Infrastructure.Contexts;

namespace MicroTec.Hr.Infrastructure.Shared
{
    internal class UnitOfWork(ApplicationDbContext dbContext, IDomainEventDispatcher domainEventDispatcher, IMapper mapper) : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IDomainEventDispatcher _domainEventDispatcher = domainEventDispatcher;
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
            => new Repository<TEntity>(_dbContext, mapper);
        public IReadOnlyRepository<TEntity> ReadOnlyRepository<TEntity>() where TEntity : class, IEntity
            => new ReadOnlyRepository<TEntity>(_dbContext, mapper);
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entitiesWithEvents = _dbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e =>
                    (e.State == EntityState.Added || e.State == EntityState.Modified)
                    && e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();


            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            // Only after successful save
            var domainEvents = GetAllDomainEvents();

            if (domainEvents.Any())
            {
                await _domainEventDispatcher.DispatchEventsAsync(entitiesWithEvents, cancellationToken);
                // Optional: Clear domain events after dispatch
                ClearAllDomainEvents();
            }

            return result;
        }

        private List<IDomainEvent> GetAllDomainEvents()
        {
            return [.. _dbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .SelectMany(e => e.Entity.DomainEvents)];
        }

        private void ClearAllDomainEvents()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.ClearDomainEvents();
            }
        }
    }
}
