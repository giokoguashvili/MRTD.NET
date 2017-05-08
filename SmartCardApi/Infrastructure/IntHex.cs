using System;
using System.Collections.Generic;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class IntHex : INumber
    {
        private readonly IBinary _hexBinary;
        public IntHex(IEnumerable<byte> hexBytes) 
            : this(new Binary(hexBytes))
        { }

        public IntHex(string hexString)
            : this(new BinaryHex(hexString))
        {
                
        }
        public IntHex(IBinary hexBinary)
        {
            _hexBinary = hexBinary;
        }
        public int Value()
        {
            var strHex = new Hex(_hexBinary).ToString();
            if (String.IsNullOrEmpty(strHex))
            {
                return 0;
            }
            return Convert.ToInt32(strHex, 16);
        }
    }
}
