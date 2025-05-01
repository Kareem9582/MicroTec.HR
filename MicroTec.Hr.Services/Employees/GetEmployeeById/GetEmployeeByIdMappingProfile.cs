using AutoMapper;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.GetEmployeeById
{
    public partial class GetEmployeeByIdMappingProfile : Profile
    {
        public GetEmployeeByIdMappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>()
                .ForMember(dest => dest.CustodiesCount, opt => opt.MapFrom(x =>x.Custodies.Count))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(x =>x.Nationality.Name));
        }
    }
}
