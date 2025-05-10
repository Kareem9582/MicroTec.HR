using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Features.Custodies;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Infrastructure.Contexts;

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
    }
}
