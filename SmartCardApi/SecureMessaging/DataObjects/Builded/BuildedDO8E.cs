using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging.CC;
using SmartCardApi.SecureMessaging.DataObjects.DO;

namespace SmartCardApi.SecureMessaging.DataObjects.Builded
{
    public class BuildedDO8E : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _rawCommandApdu;
        private readonly IBinary _kSmac;
        private readonly IBinary _kSenc;
        public BuildedDO8E(
                IBinary rawCommandApdu,
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary kSenc
            )
        {
            _rawCommandApdu = rawCommandApdu;
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _kSenc = kSenc;
        }
        public byte[] Bytes()
        {
            return new DO8E(
                        new ComputedCC(
                            _incrementedSsc,
                            _kSenc,
                            _kSmac,
                            _rawCommandApdu
                        )
                    ).Bytes();
        }
    }
}
