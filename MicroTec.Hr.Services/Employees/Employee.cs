using MicroTec.Hr.Domain.Entities;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Employees
{
    public record class Employee: BaseModel
    {
        public string EmployeeCode { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public DateTimeOffset BirthDate { get; init; }
        public List<Custody> Custodies { get; init; } = [];
        public Nationality Nationality { get; init; } = default!;
    }
}
