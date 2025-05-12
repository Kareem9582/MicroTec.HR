using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<EmployeeEntity>();
            request.EmployeeCode = await repository.GetNextEmployeeCode(_serviceProvider);
            var employee = _mapper.Map<EmployeeEntity>(request);
            employee = EmployeeEntity.Create(employee, request.UserId);

            await repository
                    .AddAsync(employee, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
