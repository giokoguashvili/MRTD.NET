using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Kenc : IBinary
    {
        private readonly IBinary _c = new BinaryHex("00000001");
        private readonly IBinary _kSeed;

        public Kenc(string mrzInformation)
            : this(
                  new Kseed(
                        new SHA1(
                            new UTF8String(mrzInformation)
                        )
                    )
               )
        {}
        public Kenc(IBinary kSeed)
        {
            _kSeed = kSeed;
        }

        public byte[] Bytes()
        {
            return new DESKeys(
                        new SHA1(
                            new D(_kSeed, _c)
                        )
                    )
                    .Key()
                    .Bytes();
        }
    }
}
