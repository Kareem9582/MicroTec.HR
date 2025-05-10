using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroTec.Hr.Domain.Features.Custodies
{
    public class CustodyEntity : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustodyNumber { get; set; }
        public string CustodyName { get; set; } = string.Empty;
        public string CustodyDescription { get; set; } = string.Empty;
        public DateTimeOffset AssignDate { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; } = null!;
    }
}
