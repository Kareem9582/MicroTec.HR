using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Features.Nationality;

namespace MicroTec.Hr.Infrastructure.Features.Nationalities
{
    public class NationalityConfiguration : IEntityTypeConfiguration<NationalityEntity>
    {
        public void Configure(EntityTypeBuilder<NationalityEntity> builder)
        {
            builder.ToTable("Nationalities");  // Name of the table in the database

            builder.HasKey(n => n.Id);  // Setting Id as the primary key

            builder.Property(n => n.Code)
                .IsRequired()
                .HasMaxLength(5);  // Ensure the code is short (e.g., "USA", "CAN")

            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(250);  // Name can be up to 250 characters

            builder.Property(n => n.ISOCode)
                .HasMaxLength(3);  // ISO codes are typically 2 or 3 characters long (e.g., "US", "CA")
        }
    }
}
