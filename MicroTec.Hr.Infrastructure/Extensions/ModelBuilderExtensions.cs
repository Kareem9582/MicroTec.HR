using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Entities;

namespace MicroTec.Hr.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Nationality>().HasData(
                new Nationality { Id = new Guid("2f532b1f-9e16-4bb5-b489-8426faadc02f"), Name = "American" },
                new Nationality { Id = new Guid("6451a8e4-1668-4147-81d1-0153c81054dc"), Name = "British" },
                new Nationality { Id = new Guid("fbf83ca1-a3eb-47ef-8f58-457a5b56b048"), Name = "Canadian" }
            );

            return builder;
        }
    }
}
