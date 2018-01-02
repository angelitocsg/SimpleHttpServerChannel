using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientChannel httpClientChannel = new HttpClientChannel();

            ChannelServices.RegisterChannel(httpClientChannel, false);

            String serviceUrl = string.Format("http://{0}:{1}/{2}", "127.0.0.1", 9090, "Services");

            WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(XmlData.ServiceCollection), serviceUrl);

            RemotingConfiguration.RegisterWellKnownClientType(remoteType);

            Console.WriteLine("Conectado no servidor, url: " + serviceUrl);

            XmlData.ServiceCollection serviceCollection = new XmlData.ServiceCollection();

            Console.WriteLine("Objeto serviceCollection criado no client");
            Console.WriteLine();

            foreach (XmlData.Service service in serviceCollection.Services)
            {
                Console.WriteLine(service.Name + "\t" + service.Status);
            }

            Console.ReadKey();
        }
    }
}
