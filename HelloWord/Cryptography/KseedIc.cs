using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class KseedIc : IBinary
    {
        private readonly IBinary _kIfd;
        private readonly IBinary _kIc;

        public KseedIc(IBinary kIfd, IBinary kIc)
        {
            _kIfd = kIfd;
            _kIc = kIc;
        }
        public byte[] Bytes()
        {
            return _kIfd
                .Bytes()
                .Zip(
                    _kIc.Bytes(),
                    (kIfdByte, kIcByte) => (byte)(kIfdByte ^ kIcByte)
                ).ToArray();
        }
    }
}
