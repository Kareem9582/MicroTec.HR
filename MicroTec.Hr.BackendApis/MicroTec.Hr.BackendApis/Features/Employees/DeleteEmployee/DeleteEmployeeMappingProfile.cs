using AutoMapper;
using MicroTec.Hr.Services.Employees.DeleteEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.DeleteEmployee
{
    public partial class DeleteEmployeeMappingProfile : Profile
    {
        public DeleteEmployeeMappingProfile()
        {
            CreateMap<DeleteEmployeeRequest, DeleteEmployeeCommand>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
