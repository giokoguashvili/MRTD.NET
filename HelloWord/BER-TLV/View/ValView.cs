using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV
{
    public class ValView
    {
        private readonly string _str;
        public ValView(string str)
        {
            _str = str;
        }

        public string View()
        {
            if (_str.Length > 50)
            {
                return String.Concat(_str.Take(50)) + "...";
            }
            else
            {
                return _str;
            }
        }
    }
}
