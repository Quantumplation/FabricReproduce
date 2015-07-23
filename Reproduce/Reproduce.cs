using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorA.Interfaces;
using ActorB.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services;

namespace Reproduce
{
    public class Reproduce : StatelessService
    {
        protected override ICommunicationListener CreateCommunicationListener()
        {
            // TODO: Replace this with an ICommunicationListener implementation if your service needs to handle user requests.
            return base.CreateCommunicationListener();
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // ActorB.Test -> ActorA.EnqueueEvent
            // Meanwhile:
            // Timer -> ActorA.Process -> ActorB.Act -> ActorA.Success
            //                                       ^-- Deadlock happens here
            await ActorProxy.Create<IActorA>(new ActorId(0)).Awake();
            await ActorProxy.Create<IActorB>(new ActorId(0)).Test();
        }
    }
}
