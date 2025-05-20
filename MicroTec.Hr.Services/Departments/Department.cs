using MicroTec.Hr.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments
{
    public record class Department : BaseModel
    {
        public string DepCode { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }
}
