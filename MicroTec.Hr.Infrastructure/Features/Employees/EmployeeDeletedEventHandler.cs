using MediatR;
using MicroTec.Hr.Domain.Features.Employees;
using Serilog;

namespace MicroTec.Hr.Infrastructure.Features.Employees
{
    public class EmployeeDeletedEventHandler : INotificationHandler<EmployeeDeletedEvent>
    {
        public Task Handle(EmployeeDeletedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information("📌 Employee Deleted Event triggered for EmployeeId: {EmployeeId} at {OccurredOn}",
                notification.EmployeeId, notification.OccurredOn);

            // You can also enrich with more data if needed

            return Task.CompletedTask;
        }
    }

}
