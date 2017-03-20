using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class PadedCommandData : IBinary
    {
        private readonly IBinary _commandData;
        private readonly byte[] _pad = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public PadedCommandData(IBinary commandData)
        {
            _commandData = commandData;
        }
        public byte[] Bytes()
        {
            return _commandData
                .Bytes()
                .Concat(_pad)
                .ToArray();
        }
    }
}


