using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO99 : IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly int _do99Length = 8;  // DO99 Format: [99][02][SW1][SW2] - 99029000 - 4 bytes - 8 chars
        public ExtractedDO99(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {

            // ProtectedResponseAPDU Format: [DO87][DO99][DOE8][SW1SW2]
            // [87][EncDataLen][01][EncData] [99][02][SW1][SW2] [8E][CCLen][CC] [SW1][SW2]
            var wrapped = new WrappedBerTLV(_protectedResponseApdu);
            var parsetBerTLV = new BerTLV(wrapped);
            return parsetBerTLV.Data.Where(tlv => tlv.T == "99").First().Bytes();
        }
    }
}
