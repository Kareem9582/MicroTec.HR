using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Services.Departments.CreateDep
{
    public class CreateDepCommandHandler : IRequestHandler<CreateDepCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public CreateDepCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public async Task<Guid> Handle(CreateDepCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<DepartmentEntity>();
            request.Code = await repository.GetNextEntityCode(_serviceProvider, e => e.Code);
          
            var Dep = _mapper.Map<DepartmentEntity>(request);
            Dep = DepartmentEntity.Create(Dep, request.UserId);

            await repository
                    .AddAsync(Dep, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Dep.Id;
        }
    }
}
