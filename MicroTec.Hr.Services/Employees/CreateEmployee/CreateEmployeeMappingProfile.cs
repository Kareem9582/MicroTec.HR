using AutoMapper;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public partial class CreateEmployeeMappingProfile : Profile
    {
        public CreateEmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeCommand, EmployeeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Custodies, opt => opt.Ignore())
                .ForMember(dest => dest.Nationality, opt => opt.Ignore());
        }
    }
}
