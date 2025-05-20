using AutoMapper;
using MicroTec.Hr.BackendApi.Features.Departments.CreateDepartment;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Services.Departments.CreateDep;

namespace MicroTec.Hr.BackendApi.Features.Departments
{
    public class DepartmentMappingProfile :Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<CreateDepartmentRequest, CreateDepCommand>();
            CreateMap<CreateDepCommand, DepartmentEntity>();

        }
    }
}
