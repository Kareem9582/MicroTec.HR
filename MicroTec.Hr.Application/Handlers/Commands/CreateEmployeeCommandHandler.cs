using MediatR;
using MicroTec.Hr.Application.Commands;
using MicroTec.Hr.Domain.Contracts;
using MicroTec.Hr.Domain.Entities;

namespace MicroTec.Hr.Application.Handlers.Commands
{
    public class CreateEmployeeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                EmployeeCode = request.EmployeeCode,
                FullName = request.FullName,
                BirthDate = request.BirthDate,
                GenderId = request.GenderId,
                NationalityId = request.NationalityId,
            };

            var resporitory = _unitOfWork.Repository<Employee>();
            await resporitory.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }

}
