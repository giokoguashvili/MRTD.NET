using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class VerifiedDO97ProtectedCommandResponse : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;

        public VerifiedDO97ProtectedCommandResponse(
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
            var _DO97ProtectedCommandResponseCC = new DO97ProtectedCommandResponseCC(
                    _incrementedSsc,
                    _kSmac,
                    new DO97ProtectedCommandResponseDO87DO99(
                        _responseApdu
                    )
                );

            var _DO97ProtectedCommandResponseDO8E = new DO97ProtectedCommandResponseDO8E(_responseApdu);
            if (
                !_DO97ProtectedCommandResponseCC
                    .Bytes()
                    .SequenceEqual(
                        _DO97ProtectedCommandResponseDO8E
                            .Bytes()
                    )
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(_DO97ProtectedCommandResponseCC),
                        new Hex(_DO97ProtectedCommandResponseDO8E)
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
                        new Hex(_DO97ProtectedCommandResponseCC),
                        new Hex(_DO97ProtectedCommandResponseDO8E)
                    );
                return _responseApdu.Bytes();
            }
        }
    }
}
