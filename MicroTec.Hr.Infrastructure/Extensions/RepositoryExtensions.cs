using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace MicroTec.Hr.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<int> GetNextEmployeeCode(this IRepository<EmployeeEntity> repository, IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var result =  await dbContext.Employees
            .AsNoTracking()
            .MaxAsync(e => (int?)e.EmployeeCode + 1) ?? 1;

            return result;

        }
        public static async Task<int> GetNextEntityCode<TEntity>(this IRepository<TEntity> repository,
         IServiceProvider serviceProvider,
         Expression<Func<TEntity, int?>> codeSelector)
            where TEntity : BaseEntity
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var result = await dbContext.Set<TEntity>()
                .AsNoTracking()
                .MaxAsync(codeSelector) ?? 1;

            return result + 1;
        }


        //public static async Task<int> GetNextEmployeeCode(this IRepository<EmployeeEntity> repository, IServiceProvider serviceProvider)
        //{
        //    using var scope = serviceProvider.CreateScope();
        //    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //    var result = await dbContext.Employees
        //    .AsNoTracking()
        //    .MaxAsync(e => (int?)e.EmployeeCode + 1) ?? 1;

        //    return result;

        //}
    }
}
