using MediatR;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Employees.GetAllEmployees
{
    public record GetAllEmployeesQuery : IRequest<PagedResult<Employee>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
        public string? SearchTerm { get; set; }
    }
}
