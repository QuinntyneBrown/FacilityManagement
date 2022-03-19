using MediatR;

namespace FacilityManagement.SharedKernel.Abstractions
{
    public interface IEvent : INotification
    {
        DateTime Created { get; }
        Guid CorrelationId { get; }
        void WithCorrelationIdFrom(IEvent @event);
    }
}
