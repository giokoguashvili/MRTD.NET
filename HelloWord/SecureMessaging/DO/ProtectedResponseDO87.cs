using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    // 8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000
    // [87][L][01]    [EncData]        [99][02][SW1][SW2][8E][08]      [CC]        [SW1][SW2]
    //  87  09 01  9FF0EC34F9922651     99  02   90  00   8E  08  AD55CC17140B2DED  90   00
    public class ProtectedResponseDO87 : IDO, IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _protectedResponseApdu;
        public ProtectedResponseDO87(
                IBinary kSenc,
                IBinary protectedResponseApdu
            )
        {
            _kSenc = kSenc;
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            
            return new DO87(_EncryptedData())
                            .Bytes();
        }

        public IBinary EncryptedData()
        {
            return _EncryptedData();
        }

        public IBinary DecryptedData()
        {
            return new TripleDES(
                    _kSenc, 
                    _EncryptedData()
                ).Decrypted();
        }

        private IBinary _EncryptedData()
        {
            var L = _protectedResponseApdu
                .Bytes()
                .Skip(1)
                .Take(1)
                .First();

            var encDataLength = new Hex(
                                    new Binary(
                                        new[] { L }
                                    )
                                ).ToInt() - 1;

            return new Binary(
                    _protectedResponseApdu
                        .Bytes()
                        .Skip(3)
                        .Take(encDataLength)
                        .ToArray()
                );
        }
    }
}
