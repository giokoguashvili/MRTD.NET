using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public class IncrementedSSC
    {
        private readonly IBinary _ssc;

        public IncrementedSSC(IBinary ssc)
        {
            _ssc = ssc;
        }

        public IBinary By(int count)
        {
            // icnrement last 4 byte by 0x01
            return
                new CombinedBinaries(
                    new Binary(_ssc.Bytes().Take(4)),
                    new BinaryNumber(
                        new Sum(
                            new IntHex(_ssc.Bytes().Skip(4)),
                            count
                        )
                    )  
                );
        }
    }
}
