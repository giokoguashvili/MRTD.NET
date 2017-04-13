using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartCardApi.MRZ;
using SmartCardApi.SmartCard;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace AgentService.Modules.SmartCard
{
    public class SmartCardModule : WebSocketBehavior
    {
        protected override async void OnMessage(MessageEventArgs e)
        {
            var mrzInfo = new MRZInfo(
                "12IB34415",
                new DateTime(1992, 06, 16),
                new DateTime(2022, 10, 08)
            );
            var dgsContent = await new SmartCardContent(mrzInfo)
                .Content();
            Send(dgsContent.Dg1Content.MRZ.NameOfHolder);
        }
    }
}
