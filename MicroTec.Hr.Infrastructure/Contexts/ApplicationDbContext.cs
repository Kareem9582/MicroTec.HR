using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Employees;
using MicroTec.Hr.Domain.Entities;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Infrastructure.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<Custody> Custodies { get; set; }
        public DbSet<NationalityEntity> Nationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
