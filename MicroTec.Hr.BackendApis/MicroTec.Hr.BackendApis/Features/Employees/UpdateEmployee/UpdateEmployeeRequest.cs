namespace MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee
{
    public record UpdateEmployeeRequest(Guid Id, string FullName, DateTimeOffset BirthDate, Guid GenderId, Guid NationalityId);
}
