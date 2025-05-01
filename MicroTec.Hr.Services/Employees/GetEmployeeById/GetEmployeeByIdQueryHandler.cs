using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<EmployeeEntity>();
            var employeeEntity = await repository.GetByIdReadOnlyAsync(request.EmployeeId,request.IncludeDeleted, request.UserId, cancellationToken) ??
                throw new RecordNotFoundException(nameof(EmployeeEntity), request.EmployeeId);

            return _mapper.Map<Employee>(employeeEntity);
        }
    }
}
