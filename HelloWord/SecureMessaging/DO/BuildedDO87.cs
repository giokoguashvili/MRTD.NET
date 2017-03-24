using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class BuildedDO87 : IBinary
    {
        private readonly IBinary _encryptedData;


        public BuildedDO87(IBinary encryptedData)
        {
            _encryptedData = encryptedData;
        }
        public byte[] Bytes()
        {
            // DO87 Format [87][EncryptedDataLength + 1][01][EncryptedData]
            return new ConcatenatedBinaries(
                    new BinaryHex("87"), 
                    new HexInt(
                        _encryptedData
                            .Bytes()
                            .Length + 1
                    ),
                    new BinaryHex("01"),
                    _encryptedData
                ).Bytes();
        }
    }
}
