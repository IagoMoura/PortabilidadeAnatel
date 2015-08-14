using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [DataContract, Serializable]
    public class Issue
    {
        [DataMember]
        public TicketStatus Status { get; set; }
        [DataMember]
        public string Detail { get; set; }
        [DataMember]
        public Portability Ticket { get; set; }
        [DataMember]
        public DateTime PortabilityDate { get; set; }
    }
}
