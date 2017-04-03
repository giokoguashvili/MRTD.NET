using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Infrastructure
{
    public class IntHex : INumber
    {
        private readonly IBinary _hexBinary;
        public IntHex(IEnumerable<byte> hexBytes) 
            : this(new Binary(hexBytes))
        { }
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
