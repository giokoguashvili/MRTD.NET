using System;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public class SelfIncrementSSC : IState<IBinary>
    {
        private readonly IBinary _ssc;
        private int _incrementCount;
        public SelfIncrementSSC(IBinary ssc)
        {
            _ssc = ssc;
        }

        public IBinary Next()
        {
            _incrementCount = _incrementCount + 1;
            return
                new Binary(
                    new IncrementedSSC(_ssc)
                        .By(_incrementCount)
                        .Bytes()
                );
        }
    }
}
