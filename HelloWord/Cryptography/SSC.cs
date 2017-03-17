using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class SSC : IBinary
    {
        private readonly IBinary _rndIc;
        private readonly IBinary _rndIf;

        public SSC(
                IBinary rndIc,
                IBinary rndIf
            )
        {
            _rndIc = rndIc;
            _rndIf = rndIf;
        }
        public byte[] Bytes()
        {
            return new LastSignificantBytes(_rndIc)
                .Bytes()
                .Concat(
                    new LastSignificantBytes(_rndIf)
                        .Bytes()
                ).ToArray();
        }

        private class LastSignificantBytes : IBinary
        {
            private readonly IBinary _binary;

            public LastSignificantBytes(IBinary binary)
            {
                _binary = binary;
            }

            public byte[] Bytes()
            {
                return _binary
                    .Bytes()
                    .Reverse()
                    .Take(4)
                    .Reverse()
                    .ToArray();
            }
        }
    }
}
