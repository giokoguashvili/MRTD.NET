using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO;
using HelloWord.SecureMessaging.ResponseDO.DO87;
using HelloWord.SecureMessaging.ResponseDO.DO97;
using HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory;
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
                new CachedBinary(
                    new ExecutedCommandApdu(
                        new DO87ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommand(),
                            _kSenc,
                            _kSmac,
                            new IncrementedSSC(_ssc).By(1)
                        ),
                        _reader
                    )
                ),
                new IncrementedSSC(_ssc).By(2),
                _kSmac,
                new DO87ProtectedCommandResponseDOFactory()
            ).Bytes();

            new VerifiedProtectedCommandResponse(
                new CachedBinary(
                    new ExecutedCommandApdu(
                        new DO97ProtectedCommandApdu(
                            new ReadBinaryCommand(4),
                            _kSenc,
                            _kSmac,
                            new IncrementedSSC(_ssc).By(3)
                        ),
                        _reader
                    )
                ),
                new IncrementedSSC(_ssc).By(4),
                _kSmac,
                new DO97ProtectedCommandResponseDOFactory()
            ).Bytes();


            return new VerifiedProtectedCommandResponse(
                    new CachedBinary(
                        new ExecutedCommandApdu(
                            new DO97ProtectedCommandApdu(
                                new ReadBinaryCommand(0x04, 18),
                                _kSenc,
                                _kSmac,
                                new IncrementedSSC(_ssc).By(5)
                            ),
                            _reader
                        )
                    ),
                    new IncrementedSSC(_ssc).By(6),
                    _kSmac,
                    new DO97ProtectedCommandResponseDOFactory()
                 ).Bytes();

        }
    }
}
