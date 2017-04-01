using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class M : IBinary
    {
        private readonly IBinary _protectedCommandHeader;
        private readonly IBinary _do87or97;
        public M(
                IBinary protectedCommandHeader,
                IBinary do87or97
            )
        {
            _protectedCommandHeader = protectedCommandHeader;
            _do87or97 = do87or97;
        }
        public byte[] Bytes()
        {
            return new CombinedBinaries(
                    _protectedCommandHeader,
                    _do87or97
                ).Bytes();
        }
    }
}
