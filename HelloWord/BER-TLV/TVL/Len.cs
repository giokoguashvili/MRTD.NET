using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.TVL.Cached;

namespace HelloWord.TVL
{
    /// <summary>
    /// ISO 7816-4 Annex D.3: Length field
    /// http://www.cardwerk.com/smartcards/smartcard_standard_ISO7816-4_annex-d.aspx 
    /// </summary>
    public class Len : IBinary
    {
        private readonly IBinary _berTvl;
        private readonly IBinary _cachedTag;
        private readonly byte _b8_one = 0x80; // 0b1000 0b000
        private readonly byte _all_one = 0xFF;// 0b1111 0b1111
        public Len(IBinary berTvl)
             : this(berTvl, new CachedTag(berTvl))
        {
        }
        public Len(
                IBinary berTvl,
                IBinary tag
            )
        {
            _berTvl = berTvl;
            _cachedTag = tag;
        }

        public byte[] Bytes()
        {
            var berTvlTagLength = _cachedTag.Bytes().Length;
            var berTvlWithoutTag = _berTvl
                                        .Bytes()
                                        .Skip(berTvlTagLength)
                                        .ToArray();
            var firstByte = berTvlWithoutTag.First();
            if (IsLongFormOfLen(firstByte))
            {
                var actualLen = new Hex(ExtractLen(firstByte)).ToInt();
                return berTvlWithoutTag
                            .Skip(1)
                            .Take(actualLen)
                            .ToArray();
            }
            else
            {
                return ExtractLen(firstByte);
            }
        }

        private byte[] ExtractLen(byte firstByteOfBerTvlWithoutTag)
        {
            return new[] { (byte)(firstByteOfBerTvlWithoutTag & _all_one) };
        }

        private bool IsLongFormOfLen(byte firstByteOfBerTvlWithoutTag)
        {
            return (firstByteOfBerTvlWithoutTag & _b8_one) == _b8_one;
        }
    }
}
