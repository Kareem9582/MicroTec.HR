using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Shared
{
    public abstract class BaseEntity : IAggregateRoot
    {
        public Guid Id { get; protected set; } = Guid.NewGuid(); // Automatically assigned at creation

        public byte[] RowVersion { get; set; } = new byte[8]; // For concurrency control

        public bool IsDeleted { get; set; }

        // Audit fields
        public Guid CreatedBy { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public Guid? UpdatedBy { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


        protected void SetCreated(Guid userId)
        {
            CreatedBy = userId;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        protected void SetUpdated(Guid userId)
        {
            UpdatedBy = userId;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        protected void SetDefaults()
        {
            // Set defaults
            Id = Guid.NewGuid();
            RowVersion = [];
            IsDeleted = false;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
