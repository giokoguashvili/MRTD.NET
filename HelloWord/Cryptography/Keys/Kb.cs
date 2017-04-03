using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.Keys
{
    public class Kb : IBinary
    {
        private readonly IBinary _kKey;
        public Kb(IBinary kKey)
        {
            _kKey = kKey;
        }
        public byte[] Bytes()
        {
            return new AdjustedParity(
                        _kKey
                            .Bytes()
                            .Skip(8)
                            .Take(8)
                            .ToArray()
                    ).Bytes();
        }
    }
}
