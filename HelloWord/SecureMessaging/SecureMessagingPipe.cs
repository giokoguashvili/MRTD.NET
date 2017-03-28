using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;

namespace HelloWord.SecureMessaging
{
    public class SecureMessagingPipe : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        private readonly IReader _reader;

        public SecureMessagingPipe(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
            _reader = reader;
        }
        public byte[] Bytes()
        {
            new VerifiedProtectedResponseApdu(
                new Cached(
                    new ExecutedCommandApdu(
                        new ProtectedCommandApdu(
                            new SelectApplicationCommandApdu(_applicationIdentifier),
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

            var firstFourBytes = new DecryptedProtectedResponseApdu(
                new Cached(
                    new VerifiedProtectedResponseApdu(
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
                    )
                ),
                _kSenc
            );

            var lackingLength = new Hex(
                new Binary(
                    firstFourBytes
                        .Bytes()
                        .Skip(1)
                        .Take(1)
                )
            ).ToInt() - 2;

            var lastBytes = new DecryptedProtectedResponseApdu(
                new Cached(
                    new VerifiedProtectedResponseApdu(
                        new Cached(
                            new ExecutedCommandApdu(
                                new ProtectedCommandApdu(
                                    new ReadBinaryCommandApdu(4, lackingLength),
                                    _kSenc,
                                    _kSmac,
                                    new IncrementedSSC(_ssc).By(5)
                                ),
                                _reader
                            )
                        ),
                        new IncrementedSSC(_ssc).By(6),
                        _kSmac
                     )
                 ),
                _kSenc
            );

            return new ConcatenatedBinaries(
                    new Binary(
                        firstFourBytes
                            .Bytes()
                            .Take(4)
                    ),
                    new Binary(
                        lastBytes
                            .Bytes()
                            .Take(lackingLength)
                    )
                ).Bytes();
        }
    }
}
