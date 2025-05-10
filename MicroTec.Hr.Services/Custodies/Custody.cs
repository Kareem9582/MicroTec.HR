using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Custodies
{
    public record class Custody : BaseModel
    {
        public string? CustodyNumber { get; init; } = string.Empty;
        public string CustodyName { get; init; } = string.Empty;
        public string EmployeeCode { get; init; } = string.Empty;
        public string CustodyDescription { get; init; } = string.Empty;
        public DateTimeOffset AssignDate { get; init; }
    }
}
