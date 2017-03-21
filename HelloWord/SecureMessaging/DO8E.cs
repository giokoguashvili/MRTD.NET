using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class DO8E : IBinary
    {
        private readonly IBinary _cc;
        private byte[] _do8e = new byte[] { 0x8E, 0x08 };

        public DO8E(IBinary cc)
        {
            _cc = cc;
        }
        public byte[] Bytes()
        {
            return _do8e
                .Concat(_cc.Bytes())
                .ToArray();
        }
    }
}
