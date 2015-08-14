using Common.Contracts;
using Common.Repository;
using Inovix.Service.ConsoleHost.KgbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Inovix.Service.ConsoleHost
{
    class Program
    {
        static Common.Contracts.Portability bilhete;
        static Common.Contracts.Customer customer;
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o cpf para migrar o telefone:");
            var cpf = Console.ReadLine();
            customer = getCustumer(cpf);
            Console.WriteLine("Customer name: {0} and telefone {1}", customer.Name, customer.Phone);
            Console.WriteLine("Validando financeiro");
            customer = ObterStatusFinanceiroCliente(cpf);
            if (customer.FinanceStatus)
            {
                Common.Contracts.Account account = ObterDadosConta(customer);
                Console.WriteLine("Account: {0} , solicitando portabilidade", account.Agency);
                abrirHost();
                bilhete = SolicitarBilhetePortabilidade(customer, account);
                Console.WriteLine("Recebido Ticket {0}. aguardando resposta anatel", bilhete.Ticket);
            }
            else
            {
                Console.WriteLine("É necessário atualizar o financeiro.");
            }

            Console.ReadKey();

            if (host != null)
            {
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }
                host.Close();
                ((IDisposable)host).Dispose();
            }
        }
        static ServiceHost host;
        private static void abrirHost()
        {
            //wait for anatel response
            Task.Factory.StartNew(() =>
            {
                Uri baseAddress = new Uri("http://localhost:8083/Inovix");
                // Create the ServiceHost.
                host = new ServiceHost(typeof(InovixService), baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                host.Open();
            });
        }

        //private static Common.Contracts.Account convert(Inovix.Service.ConsoleHost.KgbService.Account account)
        //{
        //    if (account != null)
        //    {
        //        return new AptService.Account()
        //        {
        //            AccountNumber = account.AccountNumber,
        //            Agency = account.Agency,
        //            Id = account.Id
        //        };
        //    }
        //    return null;
        //}

        //private static Common.Contracts.Customer convert(Inovix.Service.ConsoleHost.KgbService.Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return new AptService.Customer()
        //        {
        //            Cpf = customer.Cpf,
        //            FinanceStatus = customer.FinanceStatus,
        //            Id = customer.Id,
        //            Name = customer.Name,
        //            Phone = customer.Phone
        //        };
        //    }
        //    return null;
        //}

        public static Common.Contracts.Portability SolicitarBilhetePortabilidade(Common.Contracts.Customer customer, Common.Contracts.Account account)
        {
            Common.Contracts.Portability p = null;
            AptService.AptServiceClient service = null;
            try
            {
                service = new AptService.AptServiceClient();
                p = service.SolicitarBilhetePortabilidade(customer, account);
            }
            catch (Exception)
            {
                if (service != null)
                {
                    service.Abort();
                }
                throw;
            }
            finally
            {
                if (service != null)
                {
                    service.Close();
                }
            }
            return p;
        }

        public static void ServiceKGB(Action<KgbService.KgbServiceClient> client)
        {
            KgbService.KgbServiceClient service = null;
            try
            {
                service = new KgbService.KgbServiceClient();
                client(service);
            }
            catch (Exception)
            {
                if (service != null)
                {
                    service.Abort();
                }
                throw;
            }
            finally
            {
                if (service != null)
                {
                    service.Close();
                }
            }
        }

        private static Common.Contracts.Customer getCustumer(string cpf)
        {
            Common.Contracts.Customer custumer = null;
            ServiceKGB((service) =>
            {
                try
                {
                    custumer = service.GetCustomerByCPF(cpf);
                }
                catch (Exception)
                {
                    Console.WriteLine("Custumer not found");
                }

            });
            return custumer;
        }

        private static Common.Contracts.Customer ObterStatusFinanceiroCliente(string cpf)
        {
            Common.Contracts.Customer custumer = null;
            ServiceKGB((service) =>
            {
                try
                {
                    custumer = service.ObterStatusFinanceiroCliente(cpf);
                }
                catch (Exception)
                {
                    Console.WriteLine("Custumer not found");
                }

            });
            return custumer;
        }

        private static Common.Contracts.Account ObterDadosConta(Common.Contracts.Customer customer)
        {
            Common.Contracts.Account custumer = null;
            ServiceKGB((service) =>
            {
                try
                {
                    custumer = service.ObterDadosConta(customer);
                }
                catch (Exception)
                {
                    Console.WriteLine("Custumer not found");
                }

            });
            return custumer;
        }


        [ServiceContract]
        public interface IInovixService
        {
            [OperationContract]
            void RecebeRespostaAnatel(Issue issue);
        }

        public class InovixService : IInovixService
        {
            public void RecebeRespostaAnatel(Issue issue)
            {
                if (issue.Status == TicketStatus.OK)
                {
                    Console.WriteLine("Portabilidade com sucesso.");
                    Console.WriteLine("Janela de portabilidade: {0}", issue.PortabilityDate.ToString("dd/MM/yyyy hh:mm"));
                    Console.WriteLine(issue.Detail);
                    customer.PortabilityDate = issue.PortabilityDate;
                    if(atualizarYum()) Console.WriteLine("Customer atualizado");
                }
                else
                {
                    Console.WriteLine("Portabilidade falhou. Descrição: {0}", issue.Detail);

                }
                Console.WriteLine("Enter para sair");

            }
            private static bool atualizarYum()
            {
                bool p;
                YumService.YumServiceSoapClient service = null;
                try
                {
                    service = new YumService.YumServiceSoapClient();
                    p = service.UpdateCustomer(new YumService.Customer()
                    {
                        Cpf = customer.Cpf,
                        PortabilityDate = customer.PortabilityDate
                    });
                }
                catch (Exception)
                {
                    if (service != null)
                    {
                        service.Abort();
                    }
                    throw;
                }
                finally
                {
                    if (service != null)
                    {
                        service.Close();
                    }
                }
                return p;
            }

        }

    }

}
