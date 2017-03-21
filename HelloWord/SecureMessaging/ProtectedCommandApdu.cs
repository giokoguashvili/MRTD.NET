using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU.Body;
using HelloWord.CommandAPDU.Header;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _rawCommandApdu;


        public ProtectedCommandApdu(
                IBinary rawCommandApduHeader,
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
            var commandApduHeader = new CommandApduHeader(_rawCommandApdu);
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
            var do8e = new DO8E(
                            new CC(
                                new N(
                                    _incrementedSsc,
                                    new M(
                                         new ProtectedCommandApduHeader(
                                             commandApduHeader
                                        ),
                                        do87
                                    )
                                ),
                                _kSmac
                            )
                        );
            return new ConstructedProtectedCommandApdu(
                    new MaskedCommandApduHeader(commandApduHeader),
                    do87,
                    do8e
                ).Bytes();
        }
    }
}
