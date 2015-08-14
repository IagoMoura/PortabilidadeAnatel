using Common.Contracts;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KGB.Service.Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class KgbService : IKgbService
    {
        public Customer GetCustomerByCPF(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Replace(".", "").Replace("-", "").Length == 11)
            {
                var result= Repository.GetCustomers().Where(c => c.Cpf == cpf);
                if (result == null || result.Count() == 0)
                {
                    throw new FaultException<ClientNotFoundException>(new ClientNotFoundException());
                }
                return result.FirstOrDefault();
            }
            return null;
        }

        public Customer ObterStatusFinanceiroCliente(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Replace(".", "").Replace("-", "").Length == 11)
            {
                var result = Repository.GetCustomers().Where(c => c.Cpf == cpf);
                if (result == null || result.Count() == 0)
                {
                    throw new FaultException<ClientNotFoundException>(new ClientNotFoundException());
                }
                return result.FirstOrDefault();
            }
            return null;
        }

        public Account ObterDadosConta(Customer customer)
        {
            if (customer != null)
            {
                var result = Repository.GetCustomers().Where(c => c.Cpf == customer.Cpf);
                if (result == null || result.Count() == 0)
                {
                    throw new FaultException<ClientNotFoundException>(new ClientNotFoundException());
                }
                return result.FirstOrDefault().Account;
            }
            return null;
        }

    }
}
