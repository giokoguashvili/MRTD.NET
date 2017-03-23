using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Body;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging.ResponseDO.DO87
{
    public class DO87ProtectedCommandApdu : ICommandApdu
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly ICommandApdu _rawCommandApdu;


        public DO87ProtectedCommandApdu(
                ICommandApdu rawCommandApduHeader,
                IBinary kSenc,
                IBinary kSmac,
                IBinary incrementedSsc
            )
        {
            _rawCommandApdu = rawCommandApduHeader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
        }
        public byte[] Bytes()
        {
            var do87 = new CommandDO.DO87(
                           new EncryptedCommandApduData(
                               _kSenc,
                               new PadedCommandApduData(
                                   new CommandApduData(
                                       new CommandApduBody(_rawCommandApdu)
                                   )
                               )
                           )
                       );
            return new ProtectedCommandApdu(
                    _rawCommandApdu,
                    _kSmac,
                    _incrementedSsc,
                    do87
                ).Bytes();
        }

        public IsoCase Case()
        {
            return _rawCommandApdu.Case();
        }

        public SCardProtocol ActiveProtocol()
        {
            return _rawCommandApdu.ActiveProtocol();
        }

        public int ExceptedDataLength()
        {
            return 32;
        }
    }
}
