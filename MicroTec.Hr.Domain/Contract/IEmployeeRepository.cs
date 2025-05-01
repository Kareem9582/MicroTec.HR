using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeEntity employee);
        // any other needed methods
    }
}
