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
            // DO87 Format [87][EncryptedDataLength][01]
            return new ConcatenatedBinaries(
                    new BinaryHex("87"), 
                    new HexInt(
                        _encryptedData
                            .Bytes()
                            .Length
                    ),
                    new BinaryHex("01")
                ).Bytes();
        }
    }
}
