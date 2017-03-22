using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.RandomKeys
{
    public class S : IBinary
    {
        private readonly IBinary _RNDifd;
        private readonly IBinary _RNDic;
        private readonly IBinary _Kifd;
        public S(
                IBinary rndIfd,
                IBinary rndIc,
                IBinary kIfd
            )
        {
            this._Kifd = kIfd;
            this._RNDic = rndIc;
            this._RNDifd = rndIfd;
        }

        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                    _RNDifd,
                    _RNDic,
                    _Kifd
                ).Bytes();
        }
    }
}
