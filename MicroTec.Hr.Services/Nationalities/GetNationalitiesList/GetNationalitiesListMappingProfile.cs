using AutoMapper;
using MicroTec.Hr.Domain.Entities;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Nationalities.GetNationalitiesList
{
    public class GetNationalitiesListMappingProfile : Profile
    {
        public GetNationalitiesListMappingProfile()
        {
            CreateMap<NationalityEntity, BaseLookup>();

        }
    }
}
