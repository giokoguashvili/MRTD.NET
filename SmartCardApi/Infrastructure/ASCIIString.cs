using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class ASCIIString : IBinary
    {
        private readonly IBinary _asciiBinaryString;

        public ASCIIString(IEnumerable<byte> asciiStringBytes)
            : this(new Binary(asciiStringBytes))
        {}
        public ASCIIString(string asciiString)
            : this(new Binary(Encoding.ASCII.GetBytes(asciiString)))
        {}
        public ASCIIString(IBinary asciiBinaryString)
        {
            _asciiBinaryString = asciiBinaryString;
        }
        public byte[] Bytes()
        {
            return _asciiBinaryString.Bytes();
        }
        public override string ToString()
        {
            return Encoding.ASCII.GetString(_asciiBinaryString.Bytes());
        }
    }
}
