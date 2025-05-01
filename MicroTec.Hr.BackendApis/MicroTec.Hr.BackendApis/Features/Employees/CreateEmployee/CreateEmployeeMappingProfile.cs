using AutoMapper;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee
{
    public partial class CreateEmployeeMappingProfile : Profile
    {
        public CreateEmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
