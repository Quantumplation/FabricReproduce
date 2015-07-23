using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using EventStore.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace EventStore
{
    [DataContract]
    public class EventStoreState
    {
        [DataMember] public bool Received;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "EventStoreState");
        }
    }
}