using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO87 : IBinary
    {
        private readonly IBinary _protectedResponseApdu;

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
                        .Take(3 + encDataLength)
                        .ToArray()
                ).Bytes();
        }
    }
}
