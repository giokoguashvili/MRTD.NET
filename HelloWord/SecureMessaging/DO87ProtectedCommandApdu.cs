using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU;
using HelloWord.CommandAPDU.Body;
using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class DO87ProtectedCommandApdu : ICommandAPDU
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly ICommandAPDU _rawCommandApdu;


        public DO87ProtectedCommandApdu(
                ICommandAPDU rawCommandApduHeader,
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
            var do87 = new DO87(
                           new EncryptedCommandApduData(
                               _kSenc,
                               new PadedCommandApduData(
                                   new CommandData(
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
            throw new NotImplementedException();
        }

        public SCardProtocol Protocol()
        {
            throw new NotImplementedException();
        }

        public int ExceptedDataLength()
        {
            throw new NotImplementedException();
        }
    }
}
