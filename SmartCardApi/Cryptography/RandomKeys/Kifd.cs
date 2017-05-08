using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography.RandomKeys
{
    public class Kifd : IBinary
    {
        private readonly int _randomBytesCount = 16;
        public byte[] Bytes()
        {
            return new RandomBytes(_randomBytesCount)
                 .Bytes();
        }
    }
}
