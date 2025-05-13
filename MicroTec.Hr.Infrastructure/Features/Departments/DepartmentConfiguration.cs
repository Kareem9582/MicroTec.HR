using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Infrastructure.Features.Departments
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.AddBaseEntityConfiguration();

         
            builder.Property(n => n.Code)
              .IsRequired()
              .HasMaxLength(5);   

            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(500);


            builder.AddIsDeletedFilter();

            builder.AddIsDeletedIndex();

            builder.ToTable("Departments");
        }
    }
}
