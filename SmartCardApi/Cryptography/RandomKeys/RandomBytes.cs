using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography.RandomKeys
{
    public class RandomBytes : IBinary
    {
        private static readonly Random rndGenerator = new Random();
        private readonly byte[] _rndBytes;
        public RandomBytes(int bytesCount)
        {
            _rndBytes = new byte[bytesCount];
            rndGenerator.NextBytes(_rndBytes);
        }


        public byte[] Bytes()
        {
            return _rndBytes;
        }
    }
}
