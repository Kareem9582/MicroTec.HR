using MediatR;
using MicroTec.Hr.Services.Employees.GetEmployeeById;
using MicroTec.Hr.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Custom_Exceptions;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Features.Departments;

namespace MicroTec.Hr.Services.Departments.GetDepById
{
    public class GetDepByIdQueryHandler : IRequestHandler<GetDepByIdQuery, Department>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDepByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }
        public async Task<Department> Handle(GetDepByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<DepartmentEntity>();
            return await repository.GetByIdReadOnlyAsync<Department>(request.DepID, request.UserId, cancellationToken) ??
                throw new RecordNotFoundException(nameof(DepartmentEntity), request.DepID);


        }
    }
}
