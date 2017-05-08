using System;
using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class Hex
    {
        private readonly IBinary _binary;

        public Hex(IEnumerable<byte> bytes) : this(bytes.ToArray())
        { }
        public Hex(byte[] bytes) : this(new Binary(bytes))
        {}
        public Hex(IBinary binary)
        { 
            _binary = binary;
        }
        public override string ToString()
        {
            return _binary
                .Bytes()
                .ToList()
                .Aggregate(
                    String.Empty,
                    (prev, next) => prev + next.ToString("X2")
                );
        }

        public int ToInt()
        {
            var strHex = new Hex(_binary).ToString();
            if (String.IsNullOrEmpty(strHex))
            {
                return 0;
            }
            return Int32.Parse(
                       strHex,
                       System.Globalization.NumberStyles.HexNumber
                   );
        } 
    }
}
