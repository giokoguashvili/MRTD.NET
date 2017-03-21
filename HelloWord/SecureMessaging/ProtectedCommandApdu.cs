using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _m;
        private readonly IBinary _DO8E;

        public ProtectedCommandApdu(
                IBinary m,
                IBinary do8e
            )
        {
            _m = m;
            _DO8E = do8e;
        }
        public byte[] Bytes()
        {
            return _m
                .Bytes()
                .Concat(_DO8E.Bytes())
                .ToArray();

        }
    }
}
