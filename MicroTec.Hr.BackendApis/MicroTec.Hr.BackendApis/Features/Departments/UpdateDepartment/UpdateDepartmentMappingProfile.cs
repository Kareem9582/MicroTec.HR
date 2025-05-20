using AutoMapper;
using MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee;
using MicroTec.Hr.Services.Departments.UpdateDep;
using MicroTec.Hr.Services.Employees.UpdateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Departments.UpdateDepartment
{
    public class UpdateDepartmentMappingProfile : Profile
    {
        public UpdateDepartmentMappingProfile()
        {

            CreateMap<UpdateDepartmentRequest, UpdateDepCommand>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
                   .ForMember(dest => dest.UserId, opt => opt.Ignore())
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}
