using System;
using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DO.Extracted;

namespace HelloWord.SecureMessaging
{
    public class VerifiedProtectedCommandResponse : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;

        public VerifiedProtectedCommandResponse(
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
            var protectedCommandResponseCC = new CachedBinary(
                    new CC(
                        _incrementedSsc,
                        _kSmac,
                        new ConcatenatedBinaries(
                            new ExtractedDO87(_responseApdu),
                            new ExtractedDO99(_responseApdu)
                        )
                    )
               ).Bytes();

            var protectedCommandResponseDO8E = new ExtractedDO8E(_responseApdu)
                .Bytes()
                .Skip(2);
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
