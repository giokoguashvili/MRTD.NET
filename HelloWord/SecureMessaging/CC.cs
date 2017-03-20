using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class CC : IBinary
    {
        private readonly IBinary _n;
        private readonly IBinary _kSmac;

        public CC(
            IBinary n,
            IBinary kSmac)
        {
            _n = n;
            _kSmac = kSmac;
        }
        public byte[] Bytes()
        {
            return new MAC3(
                    _n,
                    _kSmac
                ).Bytes(); 
        }
    }
}
