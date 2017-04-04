using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class Kseed : IBinary
    {
        private readonly IBinary _hash;
        public Kseed(IBinary hash)
        {
            _hash = hash;
        }
        public byte[] Bytes()
        {
            return _hash
                .Bytes()
                .Take(16)
                .ToArray();
        }
    }
}
