using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU;
using HelloWord.CommandAPDU.Body;
using HelloWord.CommandAPDU.Header;
using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApdu : ICommandAPDU
    {
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _do87Or97;
        private readonly ICommandAPDU _rawCommandApdu;


        public ProtectedCommandApdu(
                ICommandAPDU rawCommandApduHeader,
                IBinary kSmac,
                IBinary incrementedSsc,
                IBinary do87or97
            )
        {
            _rawCommandApdu = rawCommandApduHeader;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
            _do87Or97 = do87or97;
        }

        public byte[] Bytes()
        {
            var commandApduHeader = new CommandApduHeader(_rawCommandApdu);

            var do8e = new DO8E(
                            new CC(
                                new N(
                                    _incrementedSsc,
                                    new M(
                                         new ProtectedCommandApduHeader(
                                             commandApduHeader
                                        ),
                                        _do87Or97
                                    )
                                ),
                                _kSmac
                            )
                        );
            return new ConstructedProtectedCommandApdu(
                    new MaskedCommandApduHeader(commandApduHeader),
                    _do87Or97,
                    do8e
                ).Bytes();
        }

        public SCardProtocol Protocol()
        {
            return this._rawCommandApdu.Protocol();
        }

        public int ExceptedDataLength()
        {
            return 32; //this._rawCommandApdu.ExceptedDataLength();
        }

        public IsoCase Case()
        {
            return IsoCase.Case4Short; //this._rawCommandApdu.Case();
        }
    }
}
