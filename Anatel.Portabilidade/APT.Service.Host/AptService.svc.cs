using Anatel.Service.Host;
using Common.Contracts;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace APT.Service.Host
{
    public class Service1 : IAptService
    {
        public Portability SolicitarBilhetePortabilidade(Customer customer, Account account)
        {
            if (customer != null && account != null)
            {
                var result = Repository.GetCustomers().Where(c => c.Cpf == customer.Cpf);
                if (result == null || result.Count() == 0)
                {
                    throw new FaultException<ClientNotFoundException>(new ClientNotFoundException());
                }

                string ticket = Guid.NewGuid().ToString();

                //wait for anatel response
                Task.Factory.StartNew(() =>
                {
                    TcpChannel tcpChannel = new TcpChannel();
                    ChannelServices.RegisterChannel(tcpChannel,false);

                    Type requiredType = typeof(AnatelObject);

                    AnatelObject remoteObject = (AnatelObject)Activator.GetObject(requiredType,
                    "tcp://localhost:9998/AnatelService");

                     var issue = remoteObject.GetTicketPortabilidade(customer,account);
                     
                     ChannelServices.UnregisterChannel(tcpChannel);
                    //send to Inovix

                     issue.Ticket = new Portability()
                     {
                         Ticket = ticket
                     };

                    //envio o isso para inovix

                });

                //send wait ticket to Inovix
                return new Portability
                {
                    Ticket = ticket
                };
            }
            return null;
        }
    }
}
