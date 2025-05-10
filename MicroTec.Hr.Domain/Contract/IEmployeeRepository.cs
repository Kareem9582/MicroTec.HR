using MicroTec.Hr.Domain.Features.Employees;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeEntity employee);
        // any other needed methods
    }
}
