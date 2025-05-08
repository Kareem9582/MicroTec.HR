using AutoMapper;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee
{
    public partial class CreateEmployeeMappingProfile : Profile
    {
        public CreateEmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>()
            .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(x=>x.Nationality))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
