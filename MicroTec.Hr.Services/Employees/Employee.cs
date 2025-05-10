using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Services.Custodies;

namespace MicroTec.Hr.Services.Employees
{
    public record class Employee : BaseModel
    {
        public string EmployeeCode { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public DateTimeOffset BirthDate { get; init; }
        public int CustodiesCount { get; init; } = 0;
        public string Nationality { get; init; } = default!;
        public Guid NationalityId { get; init; } = default!;
        public Gender Gender { get;init; }
        public IEnumerable<Custody> Custodies { get; init; } = [];
        public int Age =>
            DateTimeOffset.UtcNow.Year - BirthDate.Year -
            (BirthDate.Date > DateTimeOffset.UtcNow.AddYears(-(DateTimeOffset.UtcNow.Year - BirthDate.Year)) ? 1 : 0);

    }
}
