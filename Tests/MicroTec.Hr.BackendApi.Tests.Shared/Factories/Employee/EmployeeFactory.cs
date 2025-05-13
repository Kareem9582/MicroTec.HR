using MicroTec.Hr.BackendApi.Features.Employees;
using MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Tests.Shared.Factories.Employee
{
    public static class EmployeeFactory
    {
        // Valid request with all fields correctly populated
        public static CreateEmployeeRequest ValidRequest() => new(
            FullName: "John Doe",
            BirthDate: DateTimeOffset.Now.AddYears(-25),  // Age = 25
            Gender: Domain.Enums.Gender.Male,
            Nationality: Guid.NewGuid(),
            Custodies:  new List<CustodyRequest>()
        );

        public static CreateEmployeeRequest InvalidFullName() =>
            ValidRequest() with { FullName = "" };  // Empty name

        public static CreateEmployeeRequest InvalidBirthDateFuture() =>
            ValidRequest() with { BirthDate = DateTimeOffset.Now.AddDays(1) };  // Future date

        public static CreateEmployeeRequest InvalidBirthDateTooYoung() =>
            ValidRequest() with { BirthDate = DateTimeOffset.Now.AddYears(-10) };  // Age = 10 (MIN_AGE=18)

        public static CreateEmployeeRequest MissingNationalityId() =>
            ValidRequest() with { Nationality = Guid.Empty };  // Empty GUID
    }
}
