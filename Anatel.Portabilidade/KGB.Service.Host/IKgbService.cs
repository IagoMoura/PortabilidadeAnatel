using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KGB.Service.Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IKgbService
    {
        [OperationContract]
        Customer GetCustomerByCPF(string cpf);

        [OperationContract]
        Customer ObterStatusFinanceiroCliente(string cpf);

        [OperationContract]
        Account ObterDadosConta(Customer customer);
    }

}
