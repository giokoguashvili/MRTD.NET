using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.Keys
{
    public class Ka : IBinary
    {
        private readonly string _c = String.Empty;
        private readonly IBinary _kKey;
        public Ka(IBinary kKey)
        {
            this._kKey = kKey;
        }
        public byte[] Bytes()
        {
            return new AdjustedParity(
                        this._kKey
                            .Bytes()
                            .Skip(0)
                            .Take(8)
                            .ToArray()
                    ).Bytes();
        }
    }
}
