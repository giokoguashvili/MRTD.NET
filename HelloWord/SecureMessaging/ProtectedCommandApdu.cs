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
        private readonly IBinary _ssc;
        private readonly IBinary _rawCommandApduHeader;


        public ProtectedCommandApdu(
                IBinary rawCommandApduHeader,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc
            ) 
        {
            _rawCommandApduHeader = rawCommandApduHeader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
        }

        public byte[] Bytes()
        {
            var do87 = new DO87(
                new EncryptedCommandApduData(
                    _kSenc,
                    new CommandData(
                        new CommandApduBody(_rawCommandApduHeader)
                    )
                )
            );
            var do8e = new DO8E(
                new CC(
                    new N(
                        _ssc,
                        new M(
                            new CommandApduHeader(_rawCommandApduHeader),
                            do87
                        )
                    ),
                    _kSmac
                )
            );
            return new ConstructedProtectedCommandApdu(
                    _rawCommandApduHeader,
                    do87,
                    do8e
                ).Bytes();
        }
    }
}
