using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServerChannel httpServerChannel = new HttpServerChannel(9090);

            ChannelServices.RegisterChannel(httpServerChannel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(XmlData.ServiceCollection), "Services", WellKnownObjectMode.SingleCall);

            Console.WriteLine("Servidor criado e disponível no endereço: http://127.0.0.1:9090/Services");

            Console.ReadKey();
        }
    }
}
