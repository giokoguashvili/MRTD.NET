using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class ExternalAuthenticateCmdData : IBinary
    {
        private readonly IBinary _eIfd;
        private readonly IBinary _mIfd;
        public ExternalAuthenticateCmdData(IBinary eIfd, IBinary mIfd)
        {
            this._eIfd = eIfd;
            this._mIfd = mIfd;
        }

        public byte[] Binary()
        {
            return this._eIfd
                .Binary()
                .Concat(
                    this._mIfd
                    .Binary()
                ).ToArray();
        }
    }
}
