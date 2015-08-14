using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Anatel.Service.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            AnatelServer();
        }

        private static void AnatelServer()
        {
            Console.WriteLine("Anatel Iniciado");
            TcpChannel tcpChannel = new TcpChannel(9998);
            ChannelServices.RegisterChannel(tcpChannel,false);

            Type commonInterfaceType = typeof(AnatelObject);

            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,
            "AnatelService", WellKnownObjectMode.SingleCall);

            System.Console.WriteLine("Tecle enter para finalizar.");
            System.Console.ReadLine();
        }
    }
}
