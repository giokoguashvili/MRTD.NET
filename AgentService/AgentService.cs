using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AgentService.Modules.SmartCard;
using WebSocketSharp.Server;

namespace AgentService
{
    public partial class AgentService : ServiceBase
    {
        private readonly WebSocketServer _wsServer;

        public AgentService(WebSocketServer wsServer)
        {
            _wsServer = wsServer;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _wsServer.AddWebSocketService<SmartCardModule>("/SmartCard");
            _wsServer.Start();
        }

        protected override void OnStop()
        {
            _wsServer.Stop();
        }
    }
}
