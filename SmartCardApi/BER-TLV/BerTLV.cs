using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.TVL;
using SmartCardApi.TVL.Cached;

namespace SmartCardApi
{
    public class BerTLV : IBerTLV
    {
        private readonly IBinary _cachedTag;
        private readonly IBinary _cachedLen;
        private readonly IBinary _cachedVal;
        private readonly IBinary _cachedTlv;
        private readonly byte _b6_one = 0x20; // 0b0010 0b0000
        public BerTLV(IEnumerable<byte> bytes)
            : this(new Binary(bytes)) { }
        public BerTLV(byte[] bytes)
            : this(new Binary(bytes)) {}

        public BerTLV(string hexString) 
            : this(
                        new Cached(
                            new BinaryHex(hexString)
                        )
                  ) {}
        public BerTLV(IBinary berTlv)
        {
            _cachedTag = new CachedTag(berTlv);
            _cachedLen = new CachedLen(berTlv, _cachedTag);
            _cachedVal = new CachedVal(berTlv, _cachedTag, _cachedLen);
            _cachedTlv = new Cached(
                                new CombinedBinaries(
                                        _cachedTag,
                                        _cachedLen,
                                        _cachedVal
                                )
                          );
        }

        public string T { get { return new Hex(_cachedTag).ToString(); } } 

        public string L { get { return new Hex(_cachedLen).ToString(); } } 

        public string V { get { return new Hex(_cachedVal).ToString(); } }
        public string TL
        {
            get
            {
                return new Hex(
                            new CombinedBinaries(
                                _cachedLen,
                                _cachedVal
                            )
                       ).ToString();
            }
        }

        public IBerTLV[] Data { get { return HasConstructedData ? new ConstructedTLV(_cachedVal).Data() : new IBerTLV[0]; } }

        private bool HasConstructedData { get { return (_cachedTag.Bytes().First() & _b6_one) == _b6_one; } }

        public byte[] Bytes()
        {
            return _cachedTlv.Bytes();
        }
    }
}
