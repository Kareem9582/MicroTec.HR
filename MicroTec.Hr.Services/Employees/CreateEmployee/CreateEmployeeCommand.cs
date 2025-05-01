using MediatR;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public record class CreateEmployeeCommand : IRequest<Guid>
    {
        public string EmployeeCode { get; init; } = default!;
        public string FullName { get; init; } = default!;
        public DateTimeOffset BirthDate { get; init; }
        public Guid GenderId { get; init; }
        public Guid NationalityId { get; init; }
        public Guid UserId { get; init; }
    }
}
