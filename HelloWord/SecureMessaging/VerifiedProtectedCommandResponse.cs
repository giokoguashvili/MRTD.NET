using System;
using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;

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
            var extractedCC = new ExtractedCC(
                                    _incrementedSsc,
                                    _kSmac,
                                    _responseApdu
                                ).Bytes();
                

            var encryptedDO8E = new ExtractedDO8E(_responseApdu).EncryptedData();
            if (
                !extractedCC
                    .SequenceEqual(encryptedDO8E)
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(new Binary(extractedCC)),
                        new Hex(new Binary(encryptedDO8E))
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}",
                        new Hex(new Binary(extractedCC)),
                        new Hex(new Binary(encryptedDO8E))
                    );
                return _responseApdu.Bytes();
            }
        }
    }
}
