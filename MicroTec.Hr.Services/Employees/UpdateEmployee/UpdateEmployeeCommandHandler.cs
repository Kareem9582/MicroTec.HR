using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.Services.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmployeeCommand>
    {
        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<EmployeeEntity>();

            var employee = await repository.GetByIdAsync(request.EmployeeId, request.UserId, cancellationToken) ??
               throw new RecordNotFoundException(nameof(EmployeeEntity), request.EmployeeId);

            // Map updated fields
            employee.Update(request.FullName, request.BirthDate, request.GenderId, request.NationalityId, request.UserId);

            try
            {
                repository.Update(employee); // EF tracks changes and the RowVersion
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new BusinessException("The record was modified by another user. Please reload and try again.");
            }
        }
    }
}
