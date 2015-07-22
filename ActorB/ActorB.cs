using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorA.Interfaces;
using ActorB.Interfaces;
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
            await ActorProxy.Create<IActorA>(new ActorId(0)).EnqueuMessage(this);

            ActorEventSource.Current.ActorMessage(this, "Test End");
        }

        public async Task Act(IActorA actor)
        {

            ActorEventSource.Current.ActorMessage(this, "Act Start");
            await actor.Succeed();

            ActorEventSource.Current.ActorMessage(this, "Act End");
        }
    }
}
