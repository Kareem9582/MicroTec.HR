using MediatR;
using MicroTec.Hr.Domain.Shared;
using MicroTec.Hr.Domain.Shared.DomainEvents;
using Serilog;

namespace MicroTec.Hr.Infrastructure.Features.Employees
{
    public class EmployeeDeletedEventHandler : INotificationHandler<DeleteEvent>
    {
        public Task Handle(DeleteEvent notification, CancellationToken cancellationToken)
        {
            Log.Information("📌 Employee Deleted Event triggered for EmployeeId: {EmployeeId} at {OccurredOn}",
                notification.Id, notification.OccurredOn);

            // You can also enrich with more data if needed

            return Task.CompletedTask;
        }
    }

}
