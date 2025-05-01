using MediatR;
using MicroTec.Hr.Domain.Employees;
using Serilog;

namespace MicroTec.Hr.Infrastructure.Employees
{
    public class EmployeeUpdatedEventHandler : INotificationHandler<EmployeeUpdatedEvent>
    {
        public Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information("📌 Employee Updated Event triggered for EmployeeId: {EmployeeId} at {OccurredOn}",
                notification.EmployeeId, notification.OccurredOn);

            // You can also enrich with more data if needed

            return Task.CompletedTask;
        }
    }
}
