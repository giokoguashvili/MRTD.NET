using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AgentService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var wssv = new WebSocketSharp.Server.WebSocketServer("wss://localhost:8181");
            wssv.SslConfiguration.ServerCertificate = new X509Certificate2(Properties.Resources.SelfHost, "1");

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new AgentService(wssv)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
