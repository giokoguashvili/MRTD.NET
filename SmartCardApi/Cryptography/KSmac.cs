using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class KSmac : IBinary
    {
        private readonly IBinary _kSeedIc;

        public KSmac(IBinary kSeedIc)
        {
            _kSeedIc = kSeedIc;
        }

        public byte[] Bytes()
        {
            return new Kmac(_kSeedIc).Bytes();
        }
    }
}
