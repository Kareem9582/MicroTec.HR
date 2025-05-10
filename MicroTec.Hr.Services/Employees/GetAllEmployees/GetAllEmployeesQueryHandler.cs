using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Employees.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllEmployeesQuery, PagedResult<Employee>>
    {

        public async Task<PagedResult<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<EmployeeEntity>();
            return await repository.GetPagedReadOnlyAsync<Employee>(
                request.PageNumber,
                request.PageSize,
                request.SearchTerm,
                (query, term) =>
                {
                    if (string.IsNullOrWhiteSpace(term))
                        return query;

                    term = term.Trim().ToLower();

                    return query.Where(e =>
                        e.EmployeeCode.ToString().Contains(term) ||
                        e.FullName.ToLower().Contains(term) ||
                        e.Nationality.Name.ToLower().Contains(term) ||
                        e.Gender.ToString().Contains(term) ||
                        EF.Functions.Like(e.BirthDate.ToString(), $"%{term}%"));
                },
                cancellationToken);
        }
    }
}
