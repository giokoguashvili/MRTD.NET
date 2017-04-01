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
            var valueLength = ExtractActualLen(_len);
            var tagAndLenBytesCount = _tag.Bytes().Length + _len.Bytes().Length;
            return _berTlv
                .Bytes()
                .Skip(tagAndLenBytesCount)
                .Take(valueLength)
                .ToArray();
        }
        private int ExtractActualLen(IBinary len)
        {
            var length = len;
            if (len.Bytes().Length > 1)
            {
                length = new LongLen(len);
            }
            return new Hex(length).ToInt();
        }
    }
}
