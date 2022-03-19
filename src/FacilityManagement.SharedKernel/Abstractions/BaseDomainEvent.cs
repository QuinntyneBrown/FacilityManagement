using MediatR;

namespace FacilityManagement.SharedKernel.Abstractions
{
    public abstract class BaseDomainEvent : INotification, IEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public Guid CorrelationId { get; protected set; } = Guid.NewGuid();

        public BaseDomainEvent(BaseDomainEvent @event)
        {
            CorrelationId = @event.CorrelationId;
        }

        protected BaseDomainEvent()
        {

        }

        public void WithCorrelationIdFrom(IEvent @event)
        {

        }
    }
}
