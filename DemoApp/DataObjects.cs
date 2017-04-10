using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using SmartCardApi.DataGroups.Content;

namespace DemoApp
{
    public class DataObjects : IDataObjectContent
    {
        private readonly ISmartCard _smartCard;

        public DataObjects(ISmartCard smartCard)
        {
            _smartCard = smartCard;
        }

        public DataObjectsContent Content()
        {
            Console.WriteLine("start");
            var dg1Content = _smartCard.DG1().Content();
            var dg2Content = _smartCard.DG2().Content();
            var dg7Content = _smartCard.DG7().Content();
            var dg11Content = _smartCard.DG11().Content();
            var dg12Content = _smartCard.DG12().Content();
            Console.WriteLine("done");
            return new DataObjectsContent(
                    dg1Content,
                    dg2Content,
                    dg7Content,
                    dg11Content,
                    dg12Content
                );
        }
        
    }
}
