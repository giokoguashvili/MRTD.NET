using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class SelfIncrementSSC : IBinary
    {
        private readonly IBinary _ssc;
        private int _incrementCount = 0;
        public SelfIncrementSSC(IBinary ssc)
        {
            _ssc = ssc;
        }
        public byte[] Bytes()
        {
            _incrementCount = _incrementCount + 1;
            return new IncrementedSSC(_ssc)
                .By(_incrementCount)
                .Bytes();
        }
    }
}
