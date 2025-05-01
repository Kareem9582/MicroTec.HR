using MediatR;
using MicroTec.Hr.Domain.Employees;
using Serilog;

namespace MicroTec.Hr.Infrastructure.Employees
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
