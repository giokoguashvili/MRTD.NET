using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class HexInt : IBinary
    {
        private readonly INumber _number;

        public HexInt(INumber number)
        {
            _number = number;
        }
        public HexInt(int number) 
            : this(new Number(number))
        {}

        public byte[] Bytes()
        {
            return new BinaryHex(
                    _number
                        .Value()
                        .ToString("X2")
                ).Bytes();
        }
    }
}
