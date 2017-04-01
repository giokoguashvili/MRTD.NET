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

            // PRotectedResponseAPDU Format: [DO87][DO99][DOE8][SW1SW2]
            // [87][EncDataLen][01][EncData] [99][02][SW1][SW2] [8E][CCLen][CC] [SW1][SW2]

            if (new BytesCount(new ExtractedDO87(_protectedResponseApdu)).IsEmpty())
            {
                return _protectedResponseApdu
                            .Bytes()
                            .Take(4)
                            .ToArray();
            }

            return new BinaryHex(
                       String.Concat(
                                 new Hex(_protectedResponseApdu)
                                    .ToString()
                                    .Replace(
                                        new Hex(
                                            new ExtractedDO87(_protectedResponseApdu)
                                        ).ToString(),
                                        String.Empty
                                    )
                                    .Take(8)
                            )
                   ).Bytes();
        }
    }
}
