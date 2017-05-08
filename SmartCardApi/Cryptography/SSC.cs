using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class SSC : IBinary
    {
        private readonly IBinary _rndIc;
        private readonly IBinary _rndIfd;

        public SSC(
                IBinary rndIc,
                IBinary rndIfd
            )
        {
            _rndIc = rndIc;
            _rndIfd = rndIfd;
        }
        public byte[] Bytes()
        {
            return new CombinedBinaries(
                    new LastSignificantBytes(_rndIc),
                    new LastSignificantBytes(_rndIfd)
                ).Bytes();
        }

        private class LastSignificantBytes : IBinary
        {
            private readonly IBinary _binary;

            public LastSignificantBytes(IBinary binary)
            {
                _binary = binary;
            }

            public byte[] Bytes()
            {
                return _binary
                    .Bytes()
                    .Reverse()
                    .Take(4)
                    .Reverse()
                    .ToArray();
            }
        }
    }
}
