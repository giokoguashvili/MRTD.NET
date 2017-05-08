using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class KSenc : IBinary
    {
        private readonly IBinary _kSeedIc;

        public KSenc(IBinary kSeedIc)
        {
            _kSeedIc = kSeedIc;
        }

        public byte[] Bytes()
        {
            return new Kenc(_kSeedIc).Bytes();
        }
    }
}
