using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;

namespace HelloWord.SecureMessaging.CC
{
    public class ExtractedCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _protectedResponseApdu;

        public ExtractedCC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary protectedResponseApdu
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            if (_protectedResponseApdu.Bytes().Length == 0)
            {
                var gio = 6;
            }
            var d87 = new ExtractedDO87(_protectedResponseApdu).Bytes();
            var d99 = new ExtractedDO99(_protectedResponseApdu).Bytes();
            return new CC(
                _incrementedSsc,
                _kSmac,
                new CombinedBinaries(
                    d87,
                    d99
                )
            ).Bytes();
        }
    }
}
