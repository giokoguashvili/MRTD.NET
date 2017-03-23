using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging.ResponseDO.DO97
{
    public class DO97ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _rawCommandApdu;


        public DO97ProtectedCommandApdu(
                IBinary rawCommandApdu,
                IBinary kSenc,
                IBinary kSmac,
                IBinary incrementedSsc
            )
        {
            _rawCommandApdu = rawCommandApdu;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
        }
        public byte[] Bytes()
        {
            return new ProtectedCommandApdu(
                    _rawCommandApdu,
                    _kSmac,
                    _incrementedSsc,
                    new CommandDO.DO97(_rawCommandApdu)
                ).Bytes();
        }
    }
}
