using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace EventStore.Interfaces
{
    public interface IEventStore : IActor
    {
        Task PutMessage();
        Task<bool> IsMessageReceived();
        Task Succeed();
    }
}
