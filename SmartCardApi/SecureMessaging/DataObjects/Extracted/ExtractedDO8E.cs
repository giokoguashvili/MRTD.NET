using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO8E : IDataObject, IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly int _do8eBytesCountWithoutEncryptedData = 2;
        public ExtractedDO8E(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            // ProtectedResponseAPDU Format: [DO87][DO99][DOE8][SW1SW2]
            // [87][EncDataLen][01][EncData] [99][02][SW1][SW2] [8E][CCLen][CC] [SW1][SW2]
            var wrapped = new WrappedBerTLV(_protectedResponseApdu);
            var parsetBerTLV = new BerTLV(wrapped);
            return parsetBerTLV.Data.Where(tlv => tlv.T == "8E").First().Bytes();
        }

        public IBinary EncryptedData()
        {
            return new Binary(
                    Bytes()
                        .Skip(_do8eBytesCountWithoutEncryptedData)
                );
                
        }
    }
}
