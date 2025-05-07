using MicroTec.Hr.Domain.Enums;

namespace MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee
{
    public record class CreateEmployeeRequest(string EmployeeCode, string FullName, DateTimeOffset BirthDate, Gender Gender, Guid NationalityId);
}
