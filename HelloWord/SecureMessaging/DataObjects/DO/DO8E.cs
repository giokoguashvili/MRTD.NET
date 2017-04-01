using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.DO
{
    public class DO8E : IBinary
    {
        private readonly IBinary _computedCc;

        public DO8E(IBinary computedCC)
        {
            _computedCc = computedCC;
        }
        public byte[] Bytes()
        {
            // DO8E Format: [8E][EncodedDataLengh][EncodedData]
            return new ConcatenatedBinaries(
                    new BinaryHex("8E"),
                    new HexInt(
                        new HexCount(_computedCc)
                    ),
                    _computedCc
                ).Bytes();
        }
    }
}
