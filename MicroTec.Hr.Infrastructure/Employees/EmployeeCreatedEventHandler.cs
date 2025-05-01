using MediatR;
using MicroTec.Hr.Domain.Employees;
using Serilog;

namespace MicroTec.Hr.Infrastructure.Employees
{
    public class EmployeeCreatedEventHandler : INotificationHandler<EmployeeCreatedEvent>
    {
        public Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information("📌 EmployeeCreatedEvent triggered for EmployeeId: {EmployeeId} at {OccurredOn}",
                notification.EmployeeId, notification.OccurredOn);

            // You can also enrich with more data if needed

            return Task.CompletedTask;
        }
    }

}
