using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Body;
using Org.BouncyCastle.Asn1;

namespace HelloWord.BER_TLV
{
    public class TLV : IBinary
    {
        private readonly IBinary _berTvl;

        public TLV(IEnumerable<byte> berTlv) : this(new Binary(berTlv))
        {}
        public TLV(IBinary berTvl)
        {
            _berTvl = berTvl;
        }

        public IBinary Tag()
        {
            return new Tag(_berTvl);
        }

        public IBinary Len()
        {
            return new Len(_berTvl);
        }

        public string Val
        {
            get { return new Hex(new Val(_berTvl)).ToString(); }
        }

        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                        Tag(),
                        Len(),
                        new BinaryHex(Val)
                   ).Bytes();
        }

        public TLV[] Data
        {
            get
            {
                if (new Tag(_berTvl).HasConstructedData())
                {
                    var val = new Cached(new BinaryHex(Val));
                    var firstExistingTLV = new TLV(val);
                    return new List<TLV>()
                {
                    firstExistingTLV
                }.Concat(
                        new TLV(
                                val
                                    .Bytes()
                                    .Skip(firstExistingTLV.Bytes().Length)
                            ).Data
                    ).ToArray();
                }
                return new TLV[0];
            }
        }
    }
}
