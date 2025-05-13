using Microsoft.EntityFrameworkCore;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Departments;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Features.Nationality;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Infrastructure.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<CustodyEntity> Custodies { get; set; }
        public DbSet<NationalityEntity> Nationalities { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
