using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Entities;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Infrastructure.Configurations
{
    public class CustodyConfiguration : IEntityTypeConfiguration<Custody>
    {
        public void Configure(EntityTypeBuilder<Custody> builder)
        {
            builder.ToTable("Custodies");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.EmployeeId)
                .IsRequired();

            builder.AddIsDeletedFilter();
            //Is Deleted Index has been left deliberately as we don't need to create index for every thing considering the downside of over indexing the database . 

            // Relationship
            builder.HasOne(c => c.Employee)
                .WithMany(e => e.Custodies)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
