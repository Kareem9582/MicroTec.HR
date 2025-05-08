using MicroTec.Hr.Domain.Entities;
using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Employees
{
    public class EmployeeEntity : BaseEntity
    {
        // Props
        public int EmployeeCode { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public DateTimeOffset BirthDate { get; private set; }
        public Guid NationalityId { get; private set; }
        public Gender Gender { get; private set; }
        public List<Custody> Custodies { get; private set; } = [];
        public NationalityEntity Nationality { get; private set; } = default!;

        public static EmployeeEntity Create(EmployeeEntity employee, Guid createdBy)
        {
            EmployeeValidator.Validate(employee);

            employee.SetDefaults();
            employee.SetCreated(createdBy);

            employee.AddDomainEvent(new EmployeeCreatedEvent(employee.Id));

            return employee;
        }
        public void Update(string fullName, DateTimeOffset birthDate, Gender gender, Guid nationalityId, Guid updatedBy)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            NationalityId = nationalityId;

            SetUpdated(updatedBy);

            AddDomainEvent(new EmployeeUpdatedEvent(Id));
        }
        public void MarkForDeletion(Guid userId)
        {

            IsDeleted = true;  //Keep it if the other one doesn't work. 
            SetUpdated(userId);
            AddDomainEvent(new EmployeeDeletedEvent(Id));
        }
    }
}
