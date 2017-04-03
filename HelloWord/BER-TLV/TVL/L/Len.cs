using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.TVL.Cached;

namespace HelloWord.TVL.L
{
    /// <summary>
    /// ISO 7816-4 Annex D.3: Length field
    /// http://www.cardwerk.com/smartcards/smartcard_standard_ISO7816-4_annex-d.aspx 
    /// </summary>
    public class Len : IBinary
    {
        private readonly IBinary _berTlv;
        private readonly IBinary _cachedTag;
        private readonly byte _b8_one = 0x80; // 0b1000 0b000
        
        public Len(IBinary berTvl)
             : this(berTvl, new CachedTag(berTvl))
        {
        }
        public Len(
                IBinary berTlv,
                IBinary tag
            )
        {
            _berTlv = berTlv;
            _cachedTag = tag;
        }

        public byte[] Bytes()
        {
            var berTlvWithoutTag = _berTlv
                                        .Bytes()
                                        .Skip(
                                            new BytesCount(_cachedTag)
                                                    .Value()
                                        );

            var firstByte = berTlvWithoutTag.First();

            if (IsLongFormOfLen(firstByte))
            {
                return new CombinedBinaries(
                            new ShortLen(
                                new Binary(berTlvWithoutTag)
                            ),
                            new LongLen(
                                new Binary(berTlvWithoutTag)
                            )
                        ).Bytes();
            }
            else
            {
                return new ShortLen(
                            new Binary(berTlvWithoutTag)
                        ).Bytes();
            }
        }

        
        private bool IsLongFormOfLen(byte firstByteOfBerTvlWithoutTag)
        {
            return (firstByteOfBerTvlWithoutTag & _b8_one) == _b8_one;
        }
    }
}
