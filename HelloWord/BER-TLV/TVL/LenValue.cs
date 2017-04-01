using HelloWord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV.TVL
{
    public class LenValue : INumber
    {
        private readonly IBinary _berLen;
        public LenValue(string berLen) : this(new BinaryHex(berLen))
        {}
        public LenValue(IBinary berLen)
        {
            _berLen = berLen;
        }
        public int Value()
        {
            var lenHex = new HexCount(_berLen).Is(1) 
                                      ? (IBinary)new ShortLen(_berLen) 
                                      : new LongLen(_berLen);
            return new Hex(lenHex)
                        .ToInt();
        }
    }
}
