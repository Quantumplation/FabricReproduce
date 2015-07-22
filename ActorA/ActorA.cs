using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorA.Interfaces;
using ActorB.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace ActorA
{
    public class ActorA : Actor<ActorAState>, IActorA
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new ActorAState();
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            RegisterTimer(Process, null, TimeSpan.FromSeconds(50), TimeSpan.FromSeconds(50));
            return Task.FromResult(true);
        }

        public Task EnqueuMessage(IActorB actor)
        {

            ActorEventSource.Current.ActorMessage(this, "Enqueue");
            State.Message = actor;
            return Task.FromResult(0);

        }

        async Task Process(object notUsed)
        {
            // The need to process this stuff from a timer seems to be the critical element
            // The idea is to have an "event queue" for actor method calls that *need* to be called
            // in the future.  Is Fabric resilient enough to use things like Task.Delay() for that?
            // If not, then I have an "EventHub" actor with a priority queue processing events as they
            // become relevant.  This class mimics that.
            ActorEventSource.Current.ActorMessage(this, "Process Start");
            if (State.Message != null && State.Sent == false)
            {
                await State.Message.Act(this);
                // Even if just executing with a hard coded actor id, as below, the two block on eachother
                // await ActorProxy.Create<IActorB>(new ActorId(0)).Act(this);
                State.Sent = true;
            }

            ActorEventSource.Current.ActorMessage(this, "Process End");
        }  

        public Task Succeed()
        {
            ActorEventSource.Current.ActorMessage(this, "SUCCESS");
            return Task.FromResult(0);
        }
    }
}
