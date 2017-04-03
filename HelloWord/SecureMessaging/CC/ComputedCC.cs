using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Header;
using HelloWord.SecureMessaging.DataObjects.Builded;

namespace HelloWord.SecureMessaging.CC
{
    public class ComputedCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _unprotectedCommandApdu;

        public ComputedCC(
                IBinary incrementedSsc,
                IBinary kSenc,
                IBinary kSmac,
                IBinary unprotectedCommandApdu
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _unprotectedCommandApdu = unprotectedCommandApdu;
        }
        public byte[] Bytes()
        {
            return new CC(
                    _incrementedSsc,
                    _kSmac,
                    new CombinedBinaries(
                        new ProtectedCommandApduHeader(
                            new CommandApduHeader(_unprotectedCommandApdu)
                        ),
                        new BuildedDO87(
                            _unprotectedCommandApdu,
                            _kSenc
                        ),
                        new BuildedDO97(_unprotectedCommandApdu)
                    )
                ).Bytes();
        }
    }
}
