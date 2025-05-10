using AutoMapper;
using MicroTec.Hr.Services.Custodies;

namespace MicroTec.Hr.BackendApi.Features.Employees
{
    public partial class CustodyMappingProfile : Profile
    {
        public CustodyMappingProfile()
        {
            CreateMap<CustodyRequest, Custody>();
        }
    }
}
