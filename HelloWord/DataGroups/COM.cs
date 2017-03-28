using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.DataGroups.FileIds;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using PCSC;

namespace HelloWord.DataGroups
{
    public class COM : IBinary
    {
        private readonly IReader _reader;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        private readonly IBinary EF_COM_ID = new EF_COM();
        public COM(
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _reader = reader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
        }
        public byte[] Bytes()
        {
            new VerifiedProtectedCommandResponse(
                new Cached(
                    new ExecutedCommandApdu(
                        new ProtectedCommandApdu(
                            new SelectApplicationCommandApdu(EF_COM_ID),
                            _kSenc,
                            _kSmac,
                             new IncrementedSSC(_ssc).By(1)
                        ),
                        _reader
                    )
                ),
                new IncrementedSSC(_ssc).By(2),
                _kSmac
            ).Bytes();

            new VerifiedProtectedCommandResponse(
                new Cached(
                    new ExecutedCommandApdu(
                        new ProtectedCommandApdu(
                            new ReadBinaryCommandApdu(0, 4),
                            _kSenc,
                            _kSmac,
                            new IncrementedSSC(_ssc).By(3)
                        ),
                        _reader
                    )
                ),
                new IncrementedSSC(_ssc).By(4),
                _kSmac
            ).Bytes();


             return new VerifiedProtectedCommandResponse(
                    new Cached(
                        new ExecutedCommandApdu(
                            new ProtectedCommandApdu(
                                new ReadBinaryCommandApdu(4, 18),
                                _kSenc,
                                _kSmac,
                                new IncrementedSSC(_ssc).By(5)
                            ),
                            _reader
                        )
                    ),
                    new IncrementedSSC(_ssc).By(6),
                    _kSmac
                 ).Bytes();
        }
    }
}
