using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class Eifd : IBinary
    {
        private readonly IBinary _kEnc;
        private readonly IBinary _s;
        public Eifd(IBinary s, IBinary kEnc)
        {
            _s = s;
            _kEnc = kEnc;
        }

        public byte[] Bytes()
        {
            return new TripleDES(
                        _kEnc,
                        _s
                   )
                   .Encrypted()
                   .Bytes();
        }
    }
}
