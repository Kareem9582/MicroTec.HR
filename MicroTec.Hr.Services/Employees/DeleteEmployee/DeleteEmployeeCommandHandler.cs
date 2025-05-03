using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<EmployeeEntity>();
            var employee = await repository.GetByIdAsync(request.EmployeeId, request.UserId, cancellationToken) ??
                throw new RecordNotFoundException(nameof(EmployeeEntity), request.EmployeeId);
            employee.MarkForDeletion(request.UserId);
            repository.Delete(employee);

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
