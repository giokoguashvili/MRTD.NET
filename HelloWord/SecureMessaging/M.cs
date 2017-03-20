using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class M : IBinary
    {
        private readonly IBinary _commandHeader;
        private readonly IBinary _do87;

        public M(
                IBinary commandHeader,
                IBinary do87
            )
        {
            _commandHeader = commandHeader;
            _do87 = do87;
        }
        public byte[] Bytes()
        {
            return _commandHeader
                .Bytes()
                .Concat(_do87.Bytes())
                .ToArray();
        }
    }
}
