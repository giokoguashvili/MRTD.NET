using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
{
    public class SelfIncrementSSC : IBinary
    {
        private readonly IBinary _ssc;
        private int _incrementCount;
        public SelfIncrementSSC(IBinary ssc)
        {
            _ssc = ssc;
        }
        public byte[] Bytes()
        {
            _incrementCount = _incrementCount + 1;
            Console.WriteLine("\n\n\nSSC {0}", _incrementCount);
            return new IncrementedSSC(_ssc)
                .By(_incrementCount)
                .Bytes();
        }
    }
}
