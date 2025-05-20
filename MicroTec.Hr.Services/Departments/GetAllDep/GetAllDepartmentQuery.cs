using MediatR;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.GetAllDep
{
    public record  GetAllDepartmentQuery : IRequest<PagedResult<Department>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
        public string? SearchTerm { get; set; }
    }
}
