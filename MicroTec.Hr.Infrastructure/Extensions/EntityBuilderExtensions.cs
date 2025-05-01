using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Infrastructure.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        private const string IS_DELETED_COLUMN_NAME = "IsDeleted";
        public static EntityTypeBuilder<T> AddIsDeletedFilter<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasQueryFilter(x => !EF.Property<bool>(x, IS_DELETED_COLUMN_NAME));

            return builder;
        }
        public static EntityTypeBuilder<T> AddIsDeletedIndex<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasIndex(IS_DELETED_COLUMN_NAME)
                             .HasFilter($"[{IS_DELETED_COLUMN_NAME}] = 0");

            return builder;
        }

        public static EntityTypeBuilder<T> AddBaseEntityConfiguration<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RowVersion)
                .IsRowVersion();

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetimeoffset");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetimeoffset");

            return builder;
        }
    }
}
