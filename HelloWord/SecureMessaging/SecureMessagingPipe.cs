using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using HelloWord.Commands;
using HelloWord.DataGroups;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;

namespace HelloWord.SecureMessaging
{
    public class SecureMessagingPipe : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly INumber _bytesCountForRead;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _selfIncrementSsc;
        private readonly IReader _reader;

        public SecureMessagingPipe(
                IBinary applicationIdentifier,
                INumber bytesCountForRead,
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

            var step = 64;
            var range = Enumerable
                .Range(0, _bytesCountForRead.Value())
                .Where(index => index % step == 0)
                .Select(index => new
                {
                    StartIndex = index,
                    Count = index + step < _bytesCountForRead.Value() ? step : _bytesCountForRead.Value() % step
                });

            return range
                    .Aggregate(
                        new byte[0],
                        (prev, next) => prev.Concat(
                                            new ReadedBytesRange(
                                                    next.StartIndex,
                                                    next.Count,
                                                    _kSenc,
                                                    _kSmac,
                                                    _selfIncrementSsc,
                                                    _reader
                                                )
                                                .Bytes()
                                        ).ToArray()
                        );

            //var f1 = new DecryptedProtectedResponseApdu(
            //            new Cached(
            //                new VerifiedProtectedResponseApdu(
            //                    new Cached(
            //                        new ExecutedCommandApdu(
            //                            new ProtectedCommandApdu(
            //                                new ReadBinaryCommandApdu(0, _bytesCountForRead),
            //                                _kSenc,
            //                                _kSmac,
            //                                new Cached(_selfIncrementSsc.Bytes())
            //                            ),
            //                            _reader
            //                        )
            //                    ),
            //                    new Cached(_selfIncrementSsc.Bytes()),
            //                    _kSmac
            //                )
            //            ),
            //            _kSenc
            //        )
            //        .Bytes()
            //        .Take(_bytesCountForRead)
            //        .ToArray();

            var f2= new DecryptedProtectedResponseApdu(
                        new Cached(
                            new VerifiedProtectedResponseApdu(
                                new Cached(
                                    new ExecutedCommandApdu(
                                        new ProtectedCommandApdu(
                                            new ReadBinaryCommandApdu(0, 64),
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
                    .Take(127)
                    .ToArray();

            //var f3 = new DecryptedProtectedResponseApdu(
            //                new Cached(
            //                    new VerifiedProtectedResponseApdu(
            //                        new Cached(
            //                            new ExecutedCommandApdu(
            //                                new ProtectedCommandApdu(
            //                                    new ReadBinaryCommandApdu(127, 127),
            //                                    _kSenc,
            //                                    _kSmac,
            //                                    new Cached(_selfIncrementSsc.Bytes())
            //                                ),
            //                                _reader
            //                            )
            //                        ),
            //                        new Cached(_selfIncrementSsc.Bytes()),
            //                        _kSmac
            //                    )
            //                ),
            //                _kSenc
            //            )
            //            .Bytes()
            //            .Take(127)
            //            .ToArray();

            //var readCommand = new ReadBinaryCommandApdu(2 * 127, 127).Bytes();
            //var f4 = new DecryptedProtectedResponseApdu(
            //            new Cached(
            //                new VerifiedProtectedResponseApdu(
            //                    new Cached(
            //                        new ExecutedCommandApdu(
            //                            new ProtectedCommandApdu(
            //                                new Binary(readCommand), 
            //                                _kSenc,
            //                                _kSmac,
            //                                new Cached(_selfIncrementSsc.Bytes())
            //                            ),
            //                            _reader
            //                        )
            //                    ),
            //                    new Cached(_selfIncrementSsc.Bytes()),
            //                    _kSmac
            //                )
            //            ),
            //            _kSenc
            //        )
            //        .Bytes()
            //        .Take(127)
            //        .ToArray();


            //var readCommand5 = new ReadBinaryCommandApdu(3 * 127, 127).Bytes();
            //var f5 = new DecryptedProtectedResponseApdu(
            //            new Cached(
            //                new VerifiedProtectedResponseApdu(
            //                    new Cached(
            //                        new ExecutedCommandApdu(
            //                            new ProtectedCommandApdu(
            //                                new Binary(readCommand),
            //                                _kSenc,
            //                                _kSmac,
            //                                new Cached(_selfIncrementSsc.Bytes())
            //                            ),
            //                            _reader
            //                        )
            //                    ),
            //                    new Cached(_selfIncrementSsc.Bytes()),
            //                    _kSmac
            //                )
            //            ),
            //            _kSenc
            //        )
            //        .Bytes()
            //        .Take(127)
            //        .ToArray();


            return f2;
        }
    }
}
