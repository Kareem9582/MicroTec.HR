using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Services.Custodies;

namespace MicroTec.Hr.Services.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateEmployeeCommand>
    {
        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var EmployeeRepository = unitOfWork.Repository<EmployeeEntity>();
                var CustodyRepository = unitOfWork.Repository<CustodyEntity>();

                var employee = await EmployeeRepository.GetByIdAsync(request.EmployeeId, request.UserId, cancellationToken, q => q.Include(e => e.Custodies)) ??
                   throw new RecordNotFoundException(nameof(EmployeeEntity), request.EmployeeId);

                employee.Custodies.ForEach(x => x.MarkForDeletion(request.UserId));

                var custodies = mapper.Map<List<CustodyEntity>>(request.Custodies);
                // Map updated fields
                employee.Update(request.FullName, request.BirthDate, request.Gender, request.NationalityId, request.UserId, custodies);

                EmployeeRepository.Update(employee); // EF tracks changes and the RowVersion
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new BusinessException("The record was modified by another user. Please reload and try again.");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
