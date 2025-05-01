namespace MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee
{
    public record class CreateEmployeeRequest(string EmployeeCode, string FullName, DateTimeOffset BirthDate, Guid GenderId, Guid NationalityId);
}
