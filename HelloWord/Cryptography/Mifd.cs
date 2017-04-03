using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Mifd : IBinary
    {
        private readonly IBinary _eIfd;
        private readonly IBinary _kMac;
        public Mifd(IBinary eIfd, IBinary kMac)
        {
            _eIfd = eIfd;
            _kMac = kMac;
        }
        public byte[] Bytes()
        {
            return new MAC3(
                    _eIfd,
                    _kMac
                ).Bytes();
        }
    }
}
