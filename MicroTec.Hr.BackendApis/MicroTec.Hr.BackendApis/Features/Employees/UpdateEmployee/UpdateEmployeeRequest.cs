using MicroTec.Hr.Domain.Enums;

namespace MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee
{
    public record UpdateEmployeeRequest(Guid Id, string FullName, DateTimeOffset BirthDate, Gender Gender, Guid Nationality);
}
