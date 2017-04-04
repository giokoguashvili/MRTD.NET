using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.TVL.Cached;

namespace SmartCardApi.TVL.V
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
            var tagAndLenBytesCount = new BytesCount(
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
