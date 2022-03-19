﻿using FacilityManagement.SharedKernel.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using static Newtonsoft.Json.JsonConvert;

namespace FacilityManagement.SharedKernel.Abstractions
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        internal List<StoredEvent> _storedEvents = new List<StoredEvent>();

        [NotMapped]
        public IReadOnlyList<StoredEvent> StoredEvents => _storedEvents.AsReadOnly();

        public AggregateRoot(IEnumerable<IEvent> events)
        {
            foreach (var @event in events) { When(@event); }
        }

        public void Clear()
        {
            _storedEvents.Clear();
        }

        protected AggregateRoot()
        {

        }

        public void StoreEvent(IEvent @event)
        {
            var type = GetType();

            var eventType = @event.GetType();

            var resolvedEventType = eventType.Name == "Request" ? eventType.BaseType : eventType;

            var storedEvent = new StoredEvent
            {
                StoredEventId = Guid.NewGuid(),
                Aggregate = GetType().Name,
                AggregateDotNetType = GetType().AssemblyQualifiedName,
                Data = JsonConvert.SerializeObject(@event),
                //StreamId = (dynamic)type.GetProperty($"{type.Name}Id").GetValue(this, null)),
                DotNetType = resolvedEventType.AssemblyQualifiedName,
                Type = resolvedEventType.Name,
                CreatedOn = @event.Created,
                CorrelationId = new Guid()
            };

            _storedEvents.Add(storedEvent);
        }

        public AggregateRoot Apply(IEvent @event)
        {
            When(@event);
            EnsureValidState();
            StoreEvent(@event);
            return this;
        }
        protected abstract void When(dynamic @event);
        protected abstract void EnsureValidState();
    }
}