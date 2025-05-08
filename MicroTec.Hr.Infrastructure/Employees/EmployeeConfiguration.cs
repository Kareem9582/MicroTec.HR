using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroTec.Hr.Domain.Employees;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Infrastructure.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.AddBaseEntityConfiguration();

            builder.ToTable("Employees");

            builder.Property(e => e.EmployeeCode)
                .IsRequired();

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.BirthDate)
                .IsRequired();

            builder.Property(e => e.NationalityId)
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasConversion<string>(); 

            builder.AddIsDeletedFilter();

            builder.AddIsDeletedIndex();

            // Define relationship with Nationality
            builder.HasOne(e => e.Nationality)  // Employee has one Nationality
                .WithMany()  // Nationality can be associated with many employees
                .HasForeignKey(e => e.NationalityId)  // Foreign Key in Employee
                .OnDelete(DeleteBehavior.Restrict);  // Restrict delete (employees can't be deleted if they have a nationality)
        }
    }

}
