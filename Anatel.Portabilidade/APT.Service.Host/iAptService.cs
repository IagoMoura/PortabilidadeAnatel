using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace APT.Service.Host
{
    [ServiceContract]
    public interface IAptService
    {

        [OperationContract]
        Portability SolicitarBilhetePortabilidade(Customer customer, Account acount);
    }
}
