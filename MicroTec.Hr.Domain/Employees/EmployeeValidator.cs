using MicroTec.Hr.Domain.Custom_Exceptions;

namespace MicroTec.Hr.Domain.Employees
{
    public static class EmployeeValidator
    {
        public static void Validate(EmployeeEntity employee)
        {
            if (employee.EmployeeCode <= 0)
                throw new DomainValidationException("Employee code must Larger Than 0.");

            if (string.IsNullOrWhiteSpace(employee.FullName))
                throw new DomainValidationException("Full name is required.");

            if (employee.BirthDate > DateTime.UtcNow)
                throw new DomainValidationException("Birth date cannot be in the future.");

            var today = DateTime.UtcNow.Date;
            var age = today.Year - employee.BirthDate.Year;
            if (employee.BirthDate.Date > today.AddYears(-age)) age--; // Adjust for birthdate not yet occurred this year

            if (age < EmployeeConstants.MIN_AGE || age > EmployeeConstants.MAX_AGE)
                throw new DomainValidationException("Employee must be between 18 and 65 years old.");

            if (employee.NationalityId == Guid.Empty)
                throw new DomainValidationException("Nationality is required.");
        }
    }
}
