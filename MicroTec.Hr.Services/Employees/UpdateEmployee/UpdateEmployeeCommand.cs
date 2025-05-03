using MediatR;

namespace MicroTec.Hr.Services.Employees.UpdateEmployee
{
    public record class UpdateEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; init; }
        public string FullName { get; init; } = default!;
        public DateTimeOffset BirthDate { get; init; }
        public Guid GenderId { get; init; }
        public Guid NationalityId { get; init; }
        public Guid UserId { get; init; }
    }
}
