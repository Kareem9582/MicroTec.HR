using MicroTec.Hr.BackendApi.Features.Employees;
using MicroTec.Hr.Domain.Enums;

namespace MicroTec.Hr.BackendApi.Features.Departments.UpdateDepartment
{
    public record UpdateDepartmentRequest(Guid Id, string Name);
    
}
