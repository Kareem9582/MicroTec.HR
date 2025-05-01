using MediatR;

namespace MicroTec.Hr.Services.Employees.GetEmployeeById
{
    public record class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid EmployeeId { get; init; }
        public Guid UserId { get; init; }
        public bool IncludeDeleted { get; init; }
    }
}
