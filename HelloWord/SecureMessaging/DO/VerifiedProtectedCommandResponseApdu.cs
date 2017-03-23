using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class VerifiedProtectedCommandResponseApdu : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _responseApdu_DO99orDO87DO99;
        private readonly IBinary _responseApduDO8E;

        public VerifiedProtectedCommandResponseApdu(
                IBinary responseApdu,
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary responseApdu_DO99orDO87DO99,
                IBinary responseApduDO8E
            )
        {
            _responseApdu = responseApdu;
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _responseApdu_DO99orDO87DO99 = responseApdu_DO99orDO87DO99;
            _responseApduDO8E = responseApduDO8E;
        }
        public byte[] Bytes()
        {
            var cc = new CC(
                    new K(
                        _incrementedSsc,
                        _responseApdu_DO99orDO87DO99
                     ),
                    _kSmac
                );
            //return new If<IBinary, IBinary>(
            //            cc,
            //            responseApduDO8E,
            //            (a, b) => a.Bytes().SequenceEqual(b.Bytes())
            //        ).Result(
            //            (a, b) =>
            //            {
            //                Console.WriteLine(
            //                    "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
            //                    new Hex(cc),
            //                    new Hex(responseApduDO8E)
            //                );
            //                return b.Bytes();
            //            },
            //            (a, b) =>
            //            {
            //                throw new Exception(
            //                    String.Format(
            //                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
            //                        new Hex(cc),
            //                        new Hex(responseApduDO8E)
            //                    )
            //                );
            //            }
            //        );

            if (
                !cc
                    .Bytes()
                    .SequenceEqual(
                        _responseApduDO8E
                            .Bytes()
                    )
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(cc),
                        new Hex(_responseApduDO8E)
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
                        new Hex(cc),
                        new Hex(_responseApduDO8E)
                    );
                return _responseApdu.Bytes();
            }
        }
    }
}
