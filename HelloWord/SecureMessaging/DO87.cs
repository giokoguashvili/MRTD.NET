using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class DO87 : IBinary
    {
        private readonly IBinary _encryptedCommandData;
        private readonly byte[] _do87 = new byte[] { 0x87, 0x09, 0x01 };

        public DO87(IBinary encryptedCommandData)
        {
            _encryptedCommandData = encryptedCommandData;
        }
        public byte[] Bytes()
        {
            return _do87
                .Concat(_encryptedCommandData.Bytes())
                .ToArray();
        }
    }
}
