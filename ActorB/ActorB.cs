using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorA.Interfaces;
using ActorB.Interfaces;
using EventStore.Interfaces;
using Microsoft.ServiceFabric.Actors;

namespace ActorB
{
    public class ActorB : Actor<ActorBState>, IActorB
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new ActorBState() { };
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }

        public async Task Test()
        {
            ActorEventSource.Current.ActorMessage(this, "Test Start");
            await ActorProxy.Create<IEventStore>(new ActorId(0)).PutMessage();

            ActorEventSource.Current.ActorMessage(this, "Test End");
        }

        public async Task Act(IEventStore actor)
        {

            ActorEventSource.Current.ActorMessage(this, "Act Start");
            await actor.Succeed();

            ActorEventSource.Current.ActorMessage(this, "Act End");
        }
    }
}
