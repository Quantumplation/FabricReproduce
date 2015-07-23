using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventStore.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace EventStore
{
    public class EventStore : Actor<EventStoreState>, IEventStore
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new EventStoreState();
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }

        public async Task PutMessage()
        {
            State.Received = true;
        }

        public Task Succeed()
        {
            ActorEventSource.Current.ActorMessage(this, "SUCCESS");
            return Task.FromResult(0);
        }

        public async Task<bool> IsMessageReceived()
        {
            return State.Received;
        }
    }
}
