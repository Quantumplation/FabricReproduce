using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ActorB.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace ActorB
{
    [DataContract]
    public class ActorBState
    {

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "ActorBState");
        }
    }
}