using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Domain.Shared.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Domain.Features.Departments
{
    public class DepartmentEntity : BaseEntity
    {
        public int Code { get; private set; }
        public string Name { get; set; } = string.Empty;


        public static DepartmentEntity Create(DepartmentEntity departmentEntity, Guid createdBy)
        {
            DepartmentValidator.Validate(departmentEntity);

            departmentEntity.SetDefaults();
            departmentEntity.SetCreated(createdBy);

            departmentEntity.AddDomainEvent(new EmployeeCreatedEvent(departmentEntity.Id));

            return departmentEntity;
        }
        public void Update(string departmentName, Guid updatedBy)
        {
            this.Name = departmentName;

            SetUpdated(updatedBy);

            AddDomainEvent(new DepartmentUpdatedEvent(Id));
        }
        public void MarkForDeletion(Guid userId)
        {

            IsDeleted = true;
            SetUpdated(userId);
            AddDomainEvent(new DeleteEvent(Id));
            
        }
    }
}

