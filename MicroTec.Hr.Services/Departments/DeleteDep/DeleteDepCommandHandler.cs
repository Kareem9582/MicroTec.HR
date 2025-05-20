using AutoMapper;
using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Services.Employees.DeleteEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.DeleteDep
{
    public class DeleteDepCommandHandler : IRequestHandler<DeleteDepCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteDepCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            ArgumentNullException.ThrowIfNull(mapper);

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteDepCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<DepartmentEntity>();


            var department = await repository.GetByIdAsync(request.DepartmentId, request.UserId, cancellationToken) ??
                throw new RecordNotFoundException(nameof(DepartmentEntity), request.DepartmentId);


            department.MarkForDeletion(request.UserId);
            repository.Delete(department);

            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
