using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class VerifiedResponseApdu : IBinary
    {
        private readonly IBinary _responseApdu;
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;

        public VerifiedResponseApdu(
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
            var cc = new CC(
                    new K(
                        _incrementedSsc, 
                        new DO87ProtectedCommandResponseDO99(_responseApdu)
                     ),
                    _kSmac
                );

            var responseApduDO8E = new DO87ProtectedCommandResponseDO8E(_responseApdu);

            if (
                !cc
                    .Bytes()
                    .SequenceEqual(
                        responseApduDO8E
                            .Bytes()
                    )
            )
            {
                throw new Exception(
                    String.Format(
                        "CC not equal of DO‘8E’ of RAPDU\n{0} != {1}",
                        new Hex(cc),
                        new Hex(responseApduDO8E)
                    )
                );
            }
            else
            {
                Console.WriteLine(
                        "CC equal of DO‘8E’ of RAPDU\n{0} == {1}", 
                        new Hex(cc), 
                        new Hex(responseApduDO8E)
                    );  
                return _responseApdu.Bytes();
            }
        }
    }
}
