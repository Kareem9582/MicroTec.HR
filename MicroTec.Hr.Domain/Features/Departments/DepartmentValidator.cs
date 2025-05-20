using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Domain.Features.Departments
{
    public class DepartmentValidator
    {
        public static void Validate(DepartmentEntity department)
        {
            if (department.Code <= 0)
                throw new DomainValidationException("Department code must Larger Than 0.");

            if (string.IsNullOrWhiteSpace(department.Name))
                throw new DomainValidationException("Department name is required.");
            
        }
    }
}
