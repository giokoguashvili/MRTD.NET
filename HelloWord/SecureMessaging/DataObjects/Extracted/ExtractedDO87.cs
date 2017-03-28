using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO87 : IDataObject, IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly int _do87BytesCountWithoutEncryptedData = 3;

        public ExtractedDO87(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            if (new Hex(
                    new Binary(
                        _protectedResponseApdu
                            .Bytes()
                            .Take(1)
                    )
                ).ToString() != "87")
            {
                return new Binary().Bytes();
            }

            var L = _protectedResponseApdu
                .Bytes()
                .Skip(1)
                .Take(1)
                .First();

            var encDataLength = new Hex(
                                    new Binary(
                                        new[] { L }
                                    )
                                ).ToInt() - 1;

            return new Binary(
                    _protectedResponseApdu
                        .Bytes()
                        .Take(_do87BytesCountWithoutEncryptedData + encDataLength)
                        .ToArray()
                ).Bytes();
        }

        public IBinary EncryptedData()
        {
            return new Binary(
                Bytes()
                    .Skip(_do87BytesCountWithoutEncryptedData)
            );
        }
    }
}
