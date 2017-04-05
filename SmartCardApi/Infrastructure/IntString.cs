using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.Infrastructure
{
    public class IntString : INumber
    {
        private readonly string _strInteger;

        public IntString(char charInteger)
            : this(new string(new [] { charInteger }))
        {}
        public IntString(string strInteger)
        {
            _strInteger = strInteger;
        }
        public int Value()
        {
            return Int32.Parse(_strInteger);
        }
    }
}
