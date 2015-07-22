using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActorB.Interfaces;
using Microsoft.ServiceFabric.Actors;

namespace ActorA.Interfaces
{
    public interface IActorA : IActor
    {
        Task EnqueuMessage(IActorB actor);
        Task Succeed();
    }
}
