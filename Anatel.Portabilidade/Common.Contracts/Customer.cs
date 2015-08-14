using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [DataContract, Serializable]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Cpf { get; set; }
        [DataMember]
        public bool FinanceStatus { get; set; }
        public Account Account { get; set; }
        [DataMember]
        public DateTime PortabilityDate { get; set; }
    }
}
