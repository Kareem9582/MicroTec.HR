using AutoMapper;
using MicroTec.Hr.Domain.Features.Custodies;

namespace MicroTec.Hr.Services.Custodies
{
    public partial class CustodyMappingProfile : Profile
    {
        public CustodyMappingProfile()
        {
            CreateMap<Custody, CustodyEntity>().ReverseMap();
        }
    }
}
