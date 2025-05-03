using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeeEntity>(request);

            employee = EmployeeEntity.Create(employee, request.UserId);

            await _unitOfWork.Repository<EmployeeEntity>()
                    .AddAsync(employee, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
