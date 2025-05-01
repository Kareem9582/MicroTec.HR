using MicroTec.Hr.Domain.Employees;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Entities
{
    public class Custody : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTimeOffset AssignedDate { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; } = null!;
    }
}
