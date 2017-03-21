using System.Linq;
using HelloWord.Cryptography;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard
{
    public class ExternalAuthenticateCommandData : IBinary
    {
        private readonly string _mrzInformation;
        private readonly IBinary _rndIc;
        private readonly IBinary _rndIfd;
        private readonly IBinary _kIfd;

        public ExternalAuthenticateCommandData(
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
