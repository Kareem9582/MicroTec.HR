namespace MicroTec.Hr.Domain.Contract
{
    public interface IAggregateRoot : IEntity
    {
        public byte[] RowVersion { get; set; }
        public bool IsDeleted { get; set; }
    }
}
