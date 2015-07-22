using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorA.Interfaces;
using Microsoft.ServiceFabric.Actors;

namespace ActorB.Interfaces
{
    public interface IActorB : IActor
    {
        Task Test();
        Task Act(IActorA actor);
    }
}
