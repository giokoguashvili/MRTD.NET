using HelloWord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV
{
    public class WrapedBerTLV : IBinary
    {
        private readonly IBinary _berTlv;
        public WrapedBerTLV(IBinary berTlv)
        {
            _berTlv = berTlv;
        }

        public byte[] Bytes()
        {
            var berTlvBytesCount = new BytesCount(_berTlv).Value();
            var berLenFormat = String.Empty;
            if (berTlvBytesCount < 128)
            {
                berLenFormat = String.Format("{0}", new Hex(new HexInt(berTlvBytesCount)));
            } 
            else if (berTlvBytesCount > 127 && berTlvBytesCount < 256)
            {
               var bh =  new BinaryHex(new BytesCount(_berTlv)
                   .Value()
                    .ToString("X2"));
                berLenFormat = String.Format("81{0}", new Hex(bh));
            }
            else if ((berTlvBytesCount > 255 && berTlvBytesCount < 65536))
            {
                var bh = new BinaryHex(new BytesCount(_berTlv)
                   .Value()
                    .ToString("X4"));
                berLenFormat = String.Format("82{0}", new Hex(bh));
            }
            return new CombinedBinaries(
                    new Binary(new byte[] { 0x20 }),
                    new BinaryHex(berLenFormat),
                    _berTlv
                ).Bytes();
        }
    }
}
