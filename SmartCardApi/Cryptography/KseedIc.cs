using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class KseedIc : IBinary
    {
        private readonly IBinary _kIfd;
        private readonly IBinary _kIc;

        public KseedIc(IBinary kIfd, IBinary kIc)
        {
            _kIfd = kIfd;
            _kIc = kIc;
        }
        public byte[] Bytes()
        {
            return _kIfd
                .Bytes()
                .Zip(
                    _kIc.Bytes(),
                    (kIfdByte, kIcByte) => (byte)(kIfdByte ^ kIcByte)
                ).ToArray();
        }
    }
}
