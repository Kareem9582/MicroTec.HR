using MediatR;

namespace MicroTec.Hr.Services.Employees.DeleteEmployee
{
    public record class DeleteEmployeeCommand : IRequest<int>
    {
        public Guid EmployeeId { get; init; }
        public Guid UserId { get; init; }
    }
}
