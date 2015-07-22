using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ActorA.Interfaces;
using ActorB.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace ActorA
{
    [DataContract]
    public class ActorAState
    {
        [DataMember] public IActorB Message;
        [DataMember] public bool Sent;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "ActorAState");
        }
    }
}