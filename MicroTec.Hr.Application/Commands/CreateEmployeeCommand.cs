using MediatR;

namespace MicroTec.Hr.Application.Commands
{
    public record CreateEmployeeCommand(string EmployeeCode, string FullName, DateTime BirthDate, Guid GenderId, Guid NationalityId)
     : IRequest<Guid>;
}
