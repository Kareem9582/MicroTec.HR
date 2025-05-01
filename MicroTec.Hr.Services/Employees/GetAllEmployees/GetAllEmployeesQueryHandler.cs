using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Employees;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Employees.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllEmployeesQuery, PagedResult<Employee>>
    {

        public async Task<PagedResult<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<EmployeeEntity>();
           return await repository.GetPagedReadOnlyAsync<Employee>(request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
