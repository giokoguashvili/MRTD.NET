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
            var tag = new Tag(_berTlv);
            var len = new Cached(
                        new Len(_berTlv)
                      );

            var valueLength = new Hex(
                                len
                              ).ToInt();

            var tagAndLenBytesCount = tag.Bytes().Length + len.Bytes().Length;
            
            return _berTlv
                .Bytes()
                .Skip(tagAndLenBytesCount)
                .Take(valueLength)
                .ToArray();
        }
    }
}
