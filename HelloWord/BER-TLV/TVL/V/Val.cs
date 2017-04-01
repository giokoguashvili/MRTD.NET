using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.TVL.Cached;
using HelloWord.BER_TLV.TVL;

namespace HelloWord.TVL
{
    public class Val : IBinary
    {
        private readonly IBinary _berTlv;
        private readonly IBinary _tag;
        private readonly IBinary _len;

        public Val(IBinary berTlv)
            : this(berTlv, new CachedTag(berTlv))
        {}
        public Val(
                IBinary berTlv,
                IBinary berTag
            )
            : this(berTlv, berTag, new CachedLen(berTlv, berTag))
        {}
        public Val(
                IBinary berTlv,
                IBinary berTag,
                IBinary berLen
            )
        {
            _berTlv = berTlv;
            _tag = berTag;
            _len = berLen;
        }
        public byte[] Bytes()
        {
            var tagAndLenBytesCount = new HexCount(
                                         new CombinedBinaries(
                                             _tag,
                                             _len
                                         )
                                      ).Value();
            return _berTlv
                .Bytes()
                .Skip(tagAndLenBytesCount)
                .Take(new ValLength(_len).Value())
                .ToArray();
        }
    }
}
