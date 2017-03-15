using HelloWord.Cryptography.RandomKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class ExternalAuthenticateCmdData : IBinary
    {
        private readonly string _mrzInformation;
        private readonly IBinary _rndIc;
        private readonly IBinary _rndIfd;
        private readonly IBinary _kIfd;

        public ExternalAuthenticateCmdData(string mrzInformation, IBinary rndIc)
            : this(mrzInformation, rndIc, new RNDifd(), new Kifd())
        {
        }

        public ExternalAuthenticateCmdData(
            string mrzInformation, 
            IBinary rndIc, 
            IBinary rndIfd, 
            IBinary kIfd)
        {
            this._mrzInformation = mrzInformation;
            this._rndIc = rndIc;
            this._rndIfd = rndIfd;
            this._kIfd = kIfd;
        }
   

        public byte[] Bytes()
        {
            var kSeed = new Kseed(
                            new SHA1(
                                new UTF8String(this._mrzInformation)
                            )
                        );
            var eIfd = new Eifd(
                    new S(
                        this._rndIfd,
                        this._rndIc,
                        this._kIfd
                    ),
                    new Kenc(kSeed)
                );
            var mIfd = new Mifd(
                    eIfd,
                    new Kmac(kSeed)
                );
            return new CmdData(
                    eIfd,
                    mIfd
                ).Bytes();
        }


        private class CmdData : IBinary
        {
            private readonly IBinary _eIfd;
            private readonly IBinary _mIfd;
            public CmdData(IBinary eIfd, IBinary mIfd)
            {
                this._eIfd = eIfd;
                this._mIfd = mIfd;
            }

            public byte[] Bytes()
            {
                return this._eIfd
                    .Bytes()
                    .Concat(
                        this._mIfd
                        .Bytes()
                    ).ToArray();
            }
        }
    }
}
