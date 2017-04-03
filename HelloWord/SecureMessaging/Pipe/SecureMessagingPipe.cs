using System.Linq;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;

namespace HelloWord.SecureMessaging.Pipe
{
    public class SecureMessagingPipe : IBinary
    {
        private readonly IBinary _fid;
        private readonly INumber _bytesCountForRead;
        private readonly IReader _securedReader;

        public SecureMessagingPipe(
                IBinary fid,
                INumber bytesCountForRead,
                IReader securedReader
            )
        {
            _fid = fid;
            _bytesCountForRead = bytesCountForRead;
            _securedReader = securedReader;
        }
        public byte[] Bytes()
        {
            _securedReader
                .Transmit(new SelectApplicationCommandApdu(_fid))
                .Bytes();

            //new VerifiedProtectedResponseApdu(
            //    new Cached(
            //        new ExecutedCommandApdu(
            //            new ProtectedCommandApdu(
            //                new SelectApplicationCommandApdu(_applicationIdentifier),
            //                _kSenc,
            //                _kSmac,
            //                new Cached(_selfIncrementSsc.Bytes())
            //            ),
            //            _reader
            //        )
            //    ),
            //    new Cached(_selfIncrementSsc.Bytes()),
            //    _kSmac
            //).Bytes();
           
            var step = new Number(255);
            var range = Enumerable
                .Range(0, _bytesCountForRead.Value())
                .Where(index => index % step.Value() == 0)
                .Select(index => new
                {
                    StartIndex = new Number(index),
                    Count = new StepBytesCount(step, _bytesCountForRead, new Number(index))
                });

            //var r = new Hex(new ReadedBytesRange(
            //                                    new Number(0),
            //                                    new Number(5),
            //                                    _kSenc,
            //                                    _kSmac,
            //                                    _selfIncrementSsc,
            //                                    _reader
            //                                )
            //                                ).ToString();


            return range
                    .Aggregate(
                        new byte[0],
                        (prev, next) => prev.Concat(
                                            _securedReader.Transmit(new ReadBinaryCommandApdu(next.StartIndex, next.Count))
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

            //var f2= new DecryptedProtectedResponseApdu(
            //            new Cached(
            //                new VerifiedProtectedResponseApdu(
            //                    new Cached(
            //                        new ExecutedCommandApdu(
            //                            new ProtectedCommandApdu(
            //                                new ReadBinaryCommandApdu(0, 64),
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

        }
    }
}
