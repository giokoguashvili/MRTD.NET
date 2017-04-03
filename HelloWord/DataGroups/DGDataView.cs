using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using HelloWord.View;

namespace HelloWord.DataGroups
{
    public class DGDataView
    {
        private readonly IBerTLV[] _berTLVTree;
        public DGDataView(IBinary dgData)
        {
            _berTLVTree = new IBerTLV[] { new BerTLV(dgData) };
        }

        public void View()
        {
            new BerTLVView(_berTLVTree).View();
        }
    }
}
