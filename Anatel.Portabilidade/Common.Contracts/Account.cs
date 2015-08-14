using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [DataContract, Serializable]
    public class Account
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Agency { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
    }
}
