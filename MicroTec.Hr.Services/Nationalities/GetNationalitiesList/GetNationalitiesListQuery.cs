using MediatR;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Services.Nationalities.GetNationalitiesList
{
    public record GetNationalitiesListQuery : IRequest<IEnumerable<BaseLookup>>
    {
    }
}
