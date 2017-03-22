using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Header;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApdu : ICommandApdu
    {
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _do87Or97;
        private readonly ICommandApdu _rawCommandApdu;


        public ProtectedCommandApdu(
                ICommandApdu rawCommandApdu,
                IBinary kSmac,
                IBinary incrementedSsc,
                IBinary do87or97
            )
        {
            _rawCommandApdu = rawCommandApdu;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
            _do87Or97 = do87or97;
        }

        public byte[] Bytes()
        {
            var commandApduHeader = new CommandApduHeader(_rawCommandApdu);
            var n = new Hex(new N(
                _incrementedSsc,
                new M(
                    new ProtectedCommandApduHeader(
                        commandApduHeader
                    ),
                    _do87Or97
                )
            )).ToString();

            var ssc = new Hex(_incrementedSsc).ToString();
            var m = new Hex(new M(
                                         new ProtectedCommandApduHeader(
                                             commandApduHeader
                                        ),
                                        _do87Or97
                                    )).ToString();

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

        public SCardProtocol ActiveProtocol()
        {
            return this._rawCommandApdu.ActiveProtocol();
        }

        public int ExceptedDataLength()
        {
            return this._rawCommandApdu.ExceptedDataLength();
        }

        public IsoCase Case()
        {
            return IsoCase.Case4Short; //this._rawCommandApdu.Case();
        }
    }
}
