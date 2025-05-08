using AutoMapper;
using MicroTec.Hr.Services.Employees.UpdateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee
{
    public class UpdateEmployeeMappingProfile : Profile
    {
        public UpdateEmployeeMappingProfile()
        {
            CreateMap<UpdateEmployeeRequest, UpdateEmployeeCommand>()
                .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(x => x.Nationality))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(x => x.Id));
        }
    }
}
