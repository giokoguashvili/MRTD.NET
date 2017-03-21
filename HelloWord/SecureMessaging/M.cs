using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU.Body;
using HelloWord.CommandAPDU.Header;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class M : IBinary
    {
        private readonly IBinary _protectedCommandHeader;
        private readonly IBinary _do87;
        public M(
                IBinary protectedCommandHeader,
                IBinary do87
            )
        {
            _protectedCommandHeader = protectedCommandHeader;
            _do87 = do87;
        }
        public byte[] Bytes()
        {
            return _protectedCommandHeader
                .Bytes()
                .Concat(_do87.Bytes())
                .ToArray();
        }
    }
}
