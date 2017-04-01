using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.DO
{
    public class DO97 : IBinary
    {
        private readonly int _exceptedDataLength;
        public DO97(int exceptedDataLength)
        {
            _exceptedDataLength = exceptedDataLength;
        }
        public byte[] Bytes()
        {
            // DO97 Format [97][01][ExceptedDataLength] 
            return new CombinedBinaries(
                        new BinaryHex("9701"),
                        new HexInt(_exceptedDataLength)
                    ).Bytes();
        }
    }
}
