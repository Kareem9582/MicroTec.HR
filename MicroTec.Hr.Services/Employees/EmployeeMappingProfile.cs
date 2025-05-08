using AutoMapper;
using MicroTec.Hr.Domain.Employees;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.Services.Employees
{
    public partial class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>()
                .ForMember(dest => dest.CustodiesCount, opt => opt.MapFrom(x => x.Custodies.Count))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(x => x.Nationality.Name))
                .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(x => x.Nationality.Id))
                .ForMember(dest => dest.EmployeeCode, opt => opt.MapFrom(src =>src.EmployeeCode != 0 ? "#" +  src.EmployeeCode.ToString("D9") : "#000000000"));

            CreateMap<CreateEmployeeCommand, EmployeeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Custodies, opt => opt.Ignore())
                .ForMember(dest => dest.Nationality, opt => opt.Ignore());
        }
    }
}
