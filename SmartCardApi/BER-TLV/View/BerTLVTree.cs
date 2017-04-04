using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.View;

namespace SmartCardApi.BER_TLV.View
{
    public class BerTLVTree 
    {
        private readonly IBerTLV[] _berTlvList;

        public BerTLVTree(IBerTLV berTLV)
        {
            _berTlvList = new IBerTLV[] { berTLV };
        }

        public BerTLVEnumberable DFS()
        {
            return new BerTLVEnumberable(_berTlvList);
        }
    }
}
