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
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _selfIncrementSsc;
        private readonly IReader _reader;

        public SecureMessagingPipe(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary selfIncrementSsc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
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

            var firstFourBytes = new DecryptedProtectedResponseApdu(
                new Cached(
                    new VerifiedProtectedResponseApdu(
                        new Cached(
                            new ExecutedCommandApdu(
                                new ProtectedCommandApdu(
                                    new ReadBinaryCommandApdu(0, 4),
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
            );

            var berLenAsByte = firstFourBytes.Bytes().Skip(1).Take(1).ToArray();
            var berLenAsString = new Hex(berLenAsByte).ToString();
            if (berLenAsString.Equals("82"))
            {
                berLenAsByte = firstFourBytes.Bytes().Skip(2).Take(2).ToArray();
            }

            var str = new Hex(firstFourBytes).ToString();

            var lackingLength = new Hex(berLenAsByte).ToInt() - 2;

            //var lastBytes = new DecryptedProtectedResponseApdu(
            //    new Cached(
            //        new VerifiedProtectedResponseApdu(
            //            new Cached(
            //                new ExecutedCommandApdu(
            //                    new ProtectedCommandApdu(
            //                        new ReadBinaryCommandApdu(4, lackingLength),
            //                        _kSenc,
            //                        _kSmac,
            //                        new Cached(_selfIncrementSsc.Bytes())
            //                    ),
            //                    _reader
            //                )
            //            ),
            //            new Cached(_selfIncrementSsc.Bytes()),
            //            _kSmac
            //         )
            //     ),
            //    _kSenc
            //);

            IBinary result = new Binary();
            for (var i = 0; i <= lackingLength / 200; i ++)
            {

                var lastBytes = new DecryptedProtectedResponseApdu(
                    new Cached(
                        new VerifiedProtectedResponseApdu(
                            new Cached(
                                new ExecutedCommandApdu(
                                    new ProtectedCommandApdu(
                                        new ReadBinaryCommandApdu(i * 200, 200),
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
                ).Bytes();

                result = new ConcatenatedBinaries(
                            result,
                            new Binary(
                                lastBytes
                                    .Take(200)
                            )
                        );
            }
            var result2 = new DecryptedProtectedResponseApdu(
                    new Cached(
                        new VerifiedProtectedResponseApdu(
                            new Cached(
                                new ExecutedCommandApdu(
                                    new ProtectedCommandApdu(
                                        new ReadBinaryCommandApdu((lackingLength / 200) + 1, lackingLength % 200),
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
                );


            return new ConcatenatedBinaries(
                    result,
                    result2
                ).Bytes();
        }
    }
}
