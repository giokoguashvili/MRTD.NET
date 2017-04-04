using System;
using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.View
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
                var strLen = new BytesCount(new BinaryHex(_str)).Value();
                return String.Format("{0} ... (Hex: {1} - {2})", String.Concat(_str.Take(50)), new Hex(new HexInt(strLen)), strLen);
            }
            else
            {
                return _str;
            }
        }
    }
}
