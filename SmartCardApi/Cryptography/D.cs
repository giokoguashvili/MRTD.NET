using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class D : IBinary
    {
        private readonly IBinary _kSeed;
        private readonly IBinary _c;
        public D(IBinary kSeed, IBinary c)
        {
            _kSeed = kSeed;
            _c = c;
        }

        public byte[] Bytes()
        {
            return new CombinedBinaries(
                    _kSeed,
                    _c
                ).Bytes();
                
        }
    }
}
