using MicroTec.Hr.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Domain.Features.Departments
{
    public class DepartmentEntity : BaseEntity
    {
        public string Code { get; set; } = string.Empty;  
        public string Name { get; set; } = string.Empty; 
    }
}
