using AutoMapper;
using MicroTec.Hr.Services.Departments.GetAllDep;

namespace MicroTec.Hr.BackendApi.Features.Departments.GetAllDepartment
{
    public class GetAllDepartmentMappingProfile : Profile
    {
        public GetAllDepartmentMappingProfile()
        {
            CreateMap<GetAllDepartmentRequest, GetAllDepartmentQuery>();
        }
    }
}
