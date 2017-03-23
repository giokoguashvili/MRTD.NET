using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class VerifiedDO87ProtectedCommandResponse : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;

        public VerifiedDO87ProtectedCommandResponse(
                IBinary responseApdu,
                IBinary incrementedSsc,
                IBinary kSmac
            )
        {
            _responseApdu = responseApdu;
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
        }
        public byte[] Bytes()
        {

            var _DO87ProtectedCommandResponseCC = new DO87ProtectedCommandResponseCC(
                    _incrementedSsc,
                    _kSmac,
                    new DO87ProtectedCommandResponseDO99(
                        _responseApdu
                    )
                );

            var _DO87ProtectedCommandResponseDO8E = new DO87ProtectedCommandResponseDO8E(_responseApdu);
            if (
                !_DO87ProtectedCommandResponseCC
                    .Bytes()
                    .SequenceEqual(
                        _DO87ProtectedCommandResponseDO8E
                            .Bytes()
                    )
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(_DO87ProtectedCommandResponseCC),
                        new Hex(_DO87ProtectedCommandResponseDO8E)
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
                        new Hex(_DO87ProtectedCommandResponseCC),
                        new Hex(_DO87ProtectedCommandResponseDO8E)
                    );
                return _responseApdu.Bytes();
            }
        }
    }
}
