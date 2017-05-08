using System;
using System.Linq;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class BinaryNumber : IBinary
    {
        private readonly INumber _number;
        public BinaryNumber(int integer)
            : this(new Number(integer))
        { }
        public BinaryNumber(INumber number)
        {
            _number = number;
        }
        public byte[] Bytes()
        {
            return BitConverter
                        .GetBytes(
                            _number.Value()
                        )
                        .Reverse()
                        .ToArray();
        }
    }
}
