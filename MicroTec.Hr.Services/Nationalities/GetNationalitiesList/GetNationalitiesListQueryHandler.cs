using MediatR;
using AutoMapper;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Domain.Features.Nationality;

namespace MicroTec.Hr.Services.Nationalities.GetNationalitiesList
{
    public class GetNationalitiesListQueryHandler : IRequestHandler<GetNationalitiesListQuery, IEnumerable<BaseLookup>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNationalitiesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BaseLookup>> Handle(GetNationalitiesListQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.ReadOnlyRepository<NationalityEntity>();
            return await repository.GetAllAsync<BaseLookup>(cancellationToken);

        }
    }
}
