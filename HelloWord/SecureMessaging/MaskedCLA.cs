using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class MaskedCLA : IBinary
    {
        private readonly byte _claMaks = 0x0C;
        private readonly IBinary _cla;

        public MaskedCLA(IBinary cla)
        {
            _cla = cla;
        }
        public byte[] Bytes()
        {
            return new byte[1] {(byte) (_cla.Bytes().First() | _claMaks)};
        }
    }
}
