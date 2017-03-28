using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.DO
{
    public class DO8E : IBinary
    {
        private readonly IBinary _cc;

        public DO8E(IBinary cc)
        {
            _cc = cc;
        }
        public byte[] Bytes()
        {
            var cachedCC = new CachedBinary(_cc);
            // DO8E Format: [8E][EncodedDataLengh][EncodedData]
            return new ConcatenatedBinaries(
                    new BinaryHex("8E"),
                    new HexInt(cachedCC.Bytes().Count()),
                    cachedCC
                ).Bytes();
        }
    }
}
