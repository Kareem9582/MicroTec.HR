using AutoMapper;
using MicroTec.Hr.Services.Employees.GetAllEmployees;

namespace MicroTec.Hr.BackendApi.Features.Employees.GetAllEmployees
{
    public partial class GetAllEmployeesMappingProfile : Profile
    {
        public GetAllEmployeesMappingProfile()
        {
            CreateMap<GetAllEmployeesRequest, GetAllEmployeesQuery>();
        }
    }
}
