using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatel.Service.Host
{
    public class AnatelObject : MarshalByRefObject
    {

        public Issue GetTicketPortabilidade(Customer customer, Account account)
        {
            if (customer == null || account == null)
            {
                throw new Exception("Customer e Account obrigatórios");
            }
            DateTime portability = DateTime.Now.AddDays(4);
            Issue issue = new Issue()
            {
                Detail = String.Format("Ticket Confirmado para o telefone: {0} , data: {1}", customer.Phone, portability.ToString("dd/MM/yyyy hh:mm")),
                PortabilityDate = portability,
                Status = TicketStatus.OK
            };
            return issue;
        }
    }
}
