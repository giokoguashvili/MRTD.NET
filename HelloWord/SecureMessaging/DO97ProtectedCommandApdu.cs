using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Body;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class DO97ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly ICommandApdu _rawCommandApdu;


        public DO97ProtectedCommandApdu(
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
            var do97 = new BinaryHex("970104");
            return new ProtectedCommandApdu(
                    _rawCommandApdu,
                    _kSmac,
                    _incrementedSsc,
                    do97
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
