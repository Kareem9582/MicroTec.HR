using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Infrastructure.Extensions;
using MicroTec.Hr.Domain.Features.Custodies;

namespace MicroTec.Hr.Infrastructure.Features.Custodies
{
    public class CustodyConfiguration : IEntityTypeConfiguration<CustodyEntity>
    {
        public void Configure(EntityTypeBuilder<CustodyEntity> builder)
        {
            builder.AddBaseEntityConfiguration();

            builder.ToTable("Custodies");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CustodyName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.CustodyName)
                .IsRequired()
                .HasMaxLength(750);

            builder.Property(c => c.CustodyNumber)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.AssignDate)
                .IsRequired();

            builder.Property(c => c.EmployeeId)
                .IsRequired();

            builder.AddIsDeletedFilter();

            builder.AddIsDeletedIndex();

            // Relationship
            builder.HasOne(c => c.Employee)
                .WithMany(e => e.Custodies)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
