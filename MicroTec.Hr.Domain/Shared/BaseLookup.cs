namespace MicroTec.Hr.Domain.Shared
{
    public record BaseLookup : BaseModel
    {
        public string Name { get; init; } = string.Empty;
    }
}
