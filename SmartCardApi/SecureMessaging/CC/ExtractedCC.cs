using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SecureMessaging.DataObjects.Extracted;

namespace SmartCardApi.SecureMessaging.CC
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
            return new CC(
                        _incrementedSsc,
                        _kSmac,
                        new CombinedBinaries(
                            new ExtractedDO87(_protectedResponseApdu),
                            new ExtractedDO99(_protectedResponseApdu)
                        )
                    ).Bytes();
        }
    }
}
