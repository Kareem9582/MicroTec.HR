using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Employees
{
    public record class Employee: BaseModel
    {
        public string EmployeeCode { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public DateTimeOffset BirthDate { get; init; }
        public int CustodiesCount { get; init; } = 0;
        public string Nationality { get; init; } = default!;
        public int Age =>
            DateTimeOffset.UtcNow.Year - BirthDate.Year -
            (BirthDate.Date > DateTimeOffset.UtcNow.AddYears(-(DateTimeOffset.UtcNow.Year - BirthDate.Year)) ? 1 : 0);

    }
}
