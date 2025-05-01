using AutoMapper;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.GetEmployeeById
{
    public partial class GetEmployeeByIdMappingProfile : Profile
    {
        public GetEmployeeByIdMappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
        }
    }
}
