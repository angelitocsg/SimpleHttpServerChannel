using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlData
{
    public class ServiceCollection : MarshalByRefObject
    {
        public Service[] Services;

        public ServiceCollection()
        {
            Console.WriteLine("Criando objeto ServiceColletion no servidor.");
            List<Service> services = new List<Service>();

            Console.WriteLine("Adicionando serviço 1");
            services.Add(new Service()
            {
                Name = "Windows Update",
                Status = StatusEnum.Iniciado
            });

            Console.WriteLine("Adicionando serviço 2");
            services.Add(new Service()
            {
                Name = "SQL Server",
                Status = StatusEnum.Parado
            });

            Console.WriteLine("Adicionando serviço 3");
            services.Add(new Service()
            {
                Name = "Xpto",
                Status = StatusEnum.Pausado
            });

            Services = services.ToArray();
        }
    }
}
