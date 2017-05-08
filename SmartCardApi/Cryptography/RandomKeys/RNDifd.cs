using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography.RandomKeys
{
    public class RNDifd : IBinary
    {
        private readonly int _randomBytesCount = 8;
        public byte[] Bytes()
        {
            return new RandomBytes(_randomBytesCount).Bytes();
        }
    }
}
