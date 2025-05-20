using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Services.Employees.GetAllEmployees;
using MicroTec.Hr.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Features.Departments;

namespace MicroTec.Hr.Services.Departments.GetAllDep
{
    public class GetAllDepartmentQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllDepartmentQuery, PagedResult<Department>>
    {
        public async Task<PagedResult<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<DepartmentEntity>();
            return await repository.GetPagedReadOnlyAsync<Department>(
                request.PageNumber,
                request.PageSize,
                request.SearchTerm,
                (query, term) =>
                {
                    if (string.IsNullOrWhiteSpace(term))
                        return query;

                    term = term.Trim().ToLower();

                    return query.Where(e =>
                        e.Code.ToString().Contains(term) ||
                        e.Name.ToLower().Contains(term));



                },
                cancellationToken);
        }

        
    }
}
