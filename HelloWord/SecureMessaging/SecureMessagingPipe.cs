using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using BerTlv;
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
        private readonly IBinary _selfIncrementedSsc;
        private readonly IReader _reader;

        public SecureMessagingPipe(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary selfIncrementedSsc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _selfIncrementedSsc = selfIncrementedSsc;
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
                             new Cached(_selfIncrementedSsc.Bytes())
                        ),
                        _reader
                    )
                ),
                new Cached(_selfIncrementedSsc.Bytes()),
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
                                    new Cached(_selfIncrementedSsc.Bytes())
                                ),
                                _reader
                            )
                        ),
                        new Cached(_selfIncrementedSsc.Bytes()),
                        _kSmac
                    )
                ),
                _kSenc
            );


            var str = new Hex(firstFourBytes).ToString();

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
                                    new Cached(_selfIncrementedSsc.Bytes())
                                ),
                                _reader
                            )
                        ),
                        new Cached(_selfIncrementedSsc.Bytes()),
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
