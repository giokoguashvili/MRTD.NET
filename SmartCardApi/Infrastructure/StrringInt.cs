using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.Infrastructure
{
    public class StrringInt
    {
        private readonly INumber _integer;

        public StrringInt(INumber integer)
        {
            _integer = integer;
        }

        public override string ToString()
        {
            return _integer.ToString();
        }
    }
}
