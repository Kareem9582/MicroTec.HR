using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<EmployeeEntity>();
            return await repository.GetByIdReadOnlyAsync<Employee>(request.EmployeeId, request.UserId, cancellationToken) ??
                throw new RecordNotFoundException(nameof(EmployeeEntity), request.EmployeeId);
        }
    }
}
