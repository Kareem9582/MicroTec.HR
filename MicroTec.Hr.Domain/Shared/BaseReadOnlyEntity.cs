using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Shared
{
    public class BaseReadOnlyEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Automatically assigned at creation
    }
}
