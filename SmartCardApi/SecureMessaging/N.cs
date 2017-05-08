using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public class N : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _m;
        public N(
                IBinary incrementedSSC,
                IBinary m
            )
        {
            _incrementedSsc = incrementedSSC;
            _m = m;
        }
        //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
        public byte[] Bytes()
        {
            return new CombinedBinaries(
                        _incrementedSsc,
                        _m
                    ).Bytes();
        }
    }
}

