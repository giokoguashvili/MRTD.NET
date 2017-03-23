using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class VerifiedProtectedCommandResponse : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IProtectedCommandResponseDOFactory _protectedCommandResponseDO;

        public VerifiedProtectedCommandResponse(
                IBinary responseApdu,
                IBinary incrementedSsc,
                IBinary kSmac,
                IProtectedCommandResponseDOFactory protectedCommandResponseDO
            )
        {
            _responseApdu = responseApdu;
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _protectedCommandResponseDO = protectedCommandResponseDO;
        }
        public byte[] Bytes()
        {
            var protectedCommandResponseCC = new CC(
                    new K(
                        _incrementedSsc,
                        _protectedCommandResponseDO.DO(_responseApdu)
                     ),
                    _kSmac
                ).Bytes();

            var protectedCommandResponseDO8E = _protectedCommandResponseDO.DO8E(_responseApdu)
                .Bytes();
            if (
                !protectedCommandResponseCC
                    .SequenceEqual(protectedCommandResponseDO8E)
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(new Binary(protectedCommandResponseCC)),
                        new Hex(new Binary(protectedCommandResponseDO8E))
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
                        new Hex(new Binary(protectedCommandResponseCC)),
                        new Hex(new Binary(protectedCommandResponseDO8E))
                    );
                return _responseApdu.Bytes();
            }
        }
    }
}
