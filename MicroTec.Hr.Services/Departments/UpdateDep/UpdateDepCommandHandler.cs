using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Departments;
using MediatR;



namespace MicroTec.Hr.Services.Departments.UpdateDep
{
    public class UpdateDepCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDepCommand>
    {
        public async Task Handle(UpdateDepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departmentRepository = unitOfWork.Repository<DepartmentEntity>();

              
                var department = await departmentRepository.GetByIdAsync(request.Id, request.UserId, cancellationToken) ??
                    throw new RecordNotFoundException(nameof(DepartmentEntity), request.Id);

                department.Update(request.Name, request.UserId);

                departmentRepository.Update(department);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new BusinessException("The record was modified by another user. Please reload and try again.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
