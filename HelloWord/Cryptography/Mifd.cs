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
            this._eIfd = eIfd;
            this._kMac = kMac;
        }
        public byte[] Bytes()
        {
            return new MAC3(
                    this._eIfd,
                    this._kMac
                ).Bytes();
        }
    }
}
