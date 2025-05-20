using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Nationality;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Domain.Shared.DomainEvents;

namespace MicroTec.Hr.Domain.Features.Employees
{
    public class EmployeeEntity : BaseEntity
    {
        // Props
        public int EmployeeCode { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public DateTimeOffset BirthDate { get; private set; }
        public Guid NationalityId { get; private set; }
        public Gender Gender { get; private set; }
        public List<CustodyEntity> Custodies { get; private set; } = [];
        public NationalityEntity Nationality { get; private set; } = default!;

        public static EmployeeEntity Create(EmployeeEntity employee, Guid createdBy)
        {
            EmployeeValidator.Validate(employee);

            employee.SetDefaults();
            employee.SetCreated(createdBy);

            employee.AddDomainEvent(new EmployeeCreatedEvent(employee.Id));

            return employee;
        }
        public void Update(string fullName, DateTimeOffset birthDate, Gender gender, Guid nationalityId, Guid updatedBy, List<CustodyEntity> custodies)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            NationalityId = nationalityId;
            Custodies = custodies;

            SetUpdated(updatedBy);

            AddDomainEvent(new EmployeeUpdatedEvent(Id));
        }
        public void MarkForDeletion(Guid userId)
        {

            IsDeleted = true;  //Keep it if the other one doesn't work. 
            SetUpdated(userId);
            AddDomainEvent(new DeleteEvent(Id));
        }
    }
}
