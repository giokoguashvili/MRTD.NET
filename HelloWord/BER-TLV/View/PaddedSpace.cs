using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV
{
    public class PaddedSpace 
    {
        private readonly string _str;
        private readonly int _maxLen;
        public PaddedSpace(string str, int maxLength)
        {
            _str = str;
            _maxLen = maxLength;
        }

        public string Paded()
        {
            return _str + String.Concat(
                                    Enumerable
                                        .Range(0, _maxLen - _str.Length)
                                        .Select(i => " ")
                                );
        }
    }
}
