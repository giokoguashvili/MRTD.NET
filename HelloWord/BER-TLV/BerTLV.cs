using HelloWord.BER_TLV;
using HelloWord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BER_TLV
{
    public class BerTLV : IBerTLV, IBinary
    {
        private readonly IBinary _cachedTag;
        private readonly IBinary _cachedLen;
        private readonly IBinary _cachedVal;
        private readonly byte _b6_one = 0x20; // 0b0010 0b0000

        public BerTLV(byte[] bytes)
            : this(new Binary(bytes))
        {
        }

        public BerTLV(string hexString) 
            : this(
                    new Cached(
                        new BinaryHex(hexString)
                    )
                  )
        { 
        }
        public BerTLV(IBinary berTlv)
        {
            var tag = new Hex(new Tag(berTlv)).ToString();
            _cachedTag = new Cached(
                            new Tag(berTlv)
                         );
            _cachedLen = new Cached(
                            new Len(berTlv)
                         );
            _cachedVal = new Cached(
                            new Val(berTlv)
                         );
        }

        public string Tag => new Hex(_cachedTag).ToString();

        public string Len => new Hex(_cachedLen).ToString();

        public string Val => new Hex(_cachedVal).ToString();

        public IBerTLV[] Data => HasConstructedData ? new ConstructedTLV(_cachedVal).Data() : new IBerTLV[0];

        private bool HasConstructedData => (_cachedTag.Bytes().First() & _b6_one) == _b6_one;

        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                        _cachedTag,
                        _cachedLen,
                        _cachedVal
                   ).Bytes();
        }
    }

    public class ConstructedTLV
    {
        private readonly IBinary _constructedTLV;
        private readonly IBinary _cachedFirstExistingTLV;

        private readonly IBinary _cachedTag;
        private readonly IBinary _cachedLen;
        private readonly IBinary _cachedVal;

        public ConstructedTLV(IBinary constructedTLV)
        {
            _constructedTLV = constructedTLV;
            _cachedFirstExistingTLV = new Cached(
                                         new BerTLV(_constructedTLV)
                                            .Bytes()
                                      );
        }

        private IBerTLV First()
        {
            return new BerTLV(
                        _cachedFirstExistingTLV
                   );
        }

        private IBinary Rest()
        {
            return new Binary(
                    _constructedTLV
                        .Bytes()
                        .Skip(_cachedFirstExistingTLV.Bytes().Length)
                );
        }

        public IBerTLV[] Data()
        {
            var result = new IBerTLV[1] { First() };

            if (Rest().Bytes().Length == 0) return result;

            return result
                .Concat(
                    new ConstructedTLV(
                        Rest()
                    ).Data()
                ).ToArray();
        }
    }
}
