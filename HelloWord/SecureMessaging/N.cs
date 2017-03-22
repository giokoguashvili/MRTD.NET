using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using Org.BouncyCastle.Ocsp;

namespace HelloWord.SecureMessaging
{
    public class N : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _m;
        private readonly byte[] _pad = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00 };

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
            return new ConcatenatedBinaries(
                    _incrementedSsc,
                    _m
                    //, new Binary(_pad)
                ).Bytes();
        }
    }
}

