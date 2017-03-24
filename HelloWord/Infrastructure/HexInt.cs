using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class HexInt : IBinary
    {
        private readonly int _number;
        public HexInt(int number)
        {
            _number = number;
        }
        public byte[] Bytes()
        {
            return new BinaryHex(
                    _number
                        .ToString("X2")
                ).Bytes();
        }
    }
}
