using System;
using System.Linq;

namespace SmartCardApi.View
{
    public class BerTLVView
    {
        private readonly IBerTLV _berTlv;
        public BerTLVView(IBerTLV berTlv)
        {
            _berTlv = berTlv;
        }

        public void View()
        {
            foreach (var berTlv in new BerTLVTree(_berTlv).DFS())
            {
                Console.WriteLine(
                               "{0} - {1}",
                               berTlv.T,
                               berTlv.V
                           );
            }
        }
    }
}
