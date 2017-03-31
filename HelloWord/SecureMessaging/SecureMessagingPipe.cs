using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using BerTlv;
using HelloWord.Commands;
using HelloWord.DataGroups;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;

namespace HelloWord.SecureMessaging
{
    public class SecureMessagingPipe : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly int _bytesCountForRead;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _selfIncrementSsc;
        private readonly IReader _reader;

        public SecureMessagingPipe(
                IBinary applicationIdentifier,
                int bytesCountForRead,
                IBinary kSenc,
                IBinary kSmac,
                IBinary selfIncrementSsc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _bytesCountForRead = bytesCountForRead;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _selfIncrementSsc = selfIncrementSsc;
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
                             new Cached(_selfIncrementSsc.Bytes())
                        ),
                        _reader
                    )
                ),
                new Cached(_selfIncrementSsc.Bytes()),
                _kSmac
            ).Bytes();

            //var lackingLength = new Hex(
            //                        new BinaryHex(
            //                            new BerTLV(
            //                                firstFourBytes
            //                                    .Bytes()
            //                                    .Take(4)
            //                            ).Len
            //                        )
            //                    ).ToInt() - 2;

            //var lastBytes = new DecryptedProtectedResponseApdu(
            //                    new Cached(
            //                        new VerifiedProtectedResponseApdu(
            //                            new Cached(
            //                                new ExecutedCommandApdu(
            //                                    new ProtectedCommandApdu(
            //                                        new ReadBinaryCommandApdu(4, lackingLength),
            //                                        _kSenc,
            //                                        _kSmac,
            //                                        new Cached(_selfIncrementSsc.Bytes())
            //                                    ),
            //                                    _reader
            //                                )
            //                            ),
            //                            new Cached(_selfIncrementSsc.Bytes()),
            //                            _kSmac
            //                         )
            //                     ),
            //                    _kSenc
            //                );


            return new DecryptedProtectedResponseApdu(
                        new Cached(
                            new VerifiedProtectedResponseApdu(
                                new Cached(
                                    new ExecutedCommandApdu(
                                        new ProtectedCommandApdu(
                                            new ReadBinaryCommandApdu(0, _bytesCountForRead),
                                            _kSenc,
                                            _kSmac,
                                            new Cached(_selfIncrementSsc.Bytes())
                                        ),
                                        _reader
                                    )
                                ),
                                new Cached(_selfIncrementSsc.Bytes()),
                                _kSmac
                            )
                        ),
                        _kSenc
                    )
                    .Bytes()
                    .Take(_bytesCountForRead)
                    .ToArray();
        }
    }
}
