using AutoMapper;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Services.Departments.CreateDep;
using MicroTec.Hr.Services.Employees;
using MicroTec.Hr.Services.Employees.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments
{
    public class DepartmentMappingProfile :Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentEntity, Department>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
           .ForMember(dest => dest.DepCode, opt => opt.MapFrom(x => x.Code))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name));


            CreateMap<CreateDepCommand, DepartmentEntity>()
          .ForMember(dest => dest.Id, opt => opt.Ignore())
          .ForMember(dest => dest.RowVersion, opt => opt.Ignore())
          .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
          
         




        }
    }
}
