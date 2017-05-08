using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO87 : IDataObject, IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        public ExtractedDO87(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            // ProtectedResponseAPDU Format: [DO87][DO99][DOE8][SW1SW2]
            // [87][EncDataLen][01][EncData] [99][02][SW1][SW2] [8E][CCLen][CC] [SW1][SW2]
            var wrapped = new WrappedBerTLV(_protectedResponseApdu);
            var parsetBerTLV = new BerTLV(wrapped);
            if (parsetBerTLV.Data.Where(tlv => tlv.T == "87").Count() == 0)
                return new Binary().Bytes();

            return parsetBerTLV.Data.Where(tlv => tlv.T == "87").First().Bytes().ToArray();
        }

        public IBinary EncryptedData()
        {
            if (new BytesCount(Bytes()).Is(0)) return new Binary();

            return new Binary(
                        new BinaryHex(
                            new BerTLV(
                                Bytes()
                            ).V
                        )
                        .Bytes()
                        .Skip(1)
                   );

        }
    }
}
