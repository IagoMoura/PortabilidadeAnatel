using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Contracts
{
    [DataContract()]
    public enum TicketStatus
    {
        [EnumMember]
        OK = 1,
        [EnumMember]
        FAIL = 1,

    }
}
