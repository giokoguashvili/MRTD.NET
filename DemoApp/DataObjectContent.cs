using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.DataGroups.Content;

namespace DemoApp
{
    public class DataObjectsContent
    {
        public DG1Content Dg1Content { get; }
        public DG2Content Dg2Content { get; }
        public DG7Content Dg7Content { get; }
        public DG11Content Dg11Content { get; }
        public DG12Content Dg12Content { get; }

        public DataObjectsContent(
            DG1Content dg1Content,
            DG2Content dg2Content,
            DG7Content dg7Content,
            DG11Content dg11Content,
            DG12Content dg12Content
        )
        {
            Dg1Content = dg1Content;
            Dg2Content = dg2Content;
            Dg7Content = dg7Content;
            Dg11Content = dg11Content;
            Dg12Content = dg12Content;
        }
    }
}
