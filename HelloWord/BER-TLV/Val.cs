using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
{
    public class Val : IBinary
    {
        private readonly IBinary _berTlv;
        public Val(IBinary berTlv)
        {
            _berTlv = berTlv;
        }
        public byte[] Bytes()
        {
            var valueLength = new Hex(
                                new Len(_berTlv)
                              ).ToInt();
            return _berTlv
                .Bytes()
                .Reverse()
                .Take(valueLength)
                .Reverse()
                .ToArray();
        }
    }
}
