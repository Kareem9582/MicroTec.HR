using MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Tests.Features.Employees.Factories
{
    public static class EmployeeFactory
    {
        // Valid request with all fields correctly populated
        public static CreateEmployeeRequest ValidRequest() => new(
            EmployeeCode: "EMP-12345",  // 9 chars
            FullName: "John Doe",
            BirthDate: DateTimeOffset.Now.AddYears(-25),  // Age = 25
            GenderId: Guid.NewGuid(),
            NationalityId: Guid.NewGuid()
        );

        // Invalid requests targeting specific validation rules
        public static CreateEmployeeRequest InvalidEmployeeCode() =>
            ValidRequest() with { EmployeeCode = "TOO-LONG-CODE" };  // Violates 9-char rule

        public static CreateEmployeeRequest InvalidFullName() =>
            ValidRequest() with { FullName = "" };  // Empty name

        public static CreateEmployeeRequest InvalidBirthDateFuture() =>
            ValidRequest() with { BirthDate = DateTimeOffset.Now.AddDays(1) };  // Future date

        public static CreateEmployeeRequest InvalidBirthDateTooYoung() =>
            ValidRequest() with { BirthDate = DateTimeOffset.Now.AddYears(-10) };  // Age = 10 (MIN_AGE=18)

        public static CreateEmployeeRequest MissingGenderId() =>
            ValidRequest() with { GenderId = Guid.Empty };  // Empty GUID

        public static CreateEmployeeRequest MissingNationalityId() =>
            ValidRequest() with { NationalityId = Guid.Empty };  // Empty GUID
    }
}
