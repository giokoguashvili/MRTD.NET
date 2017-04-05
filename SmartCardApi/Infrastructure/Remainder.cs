using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.Infrastructure
{
    public class Remainder : INumber
    {
        private readonly INumber _a;
        private readonly INumber _b;
        private readonly Func<int, int, int> mod = (a, b) => a % b;
        public Remainder(int a, INumber b) : this(new Number(a), b)
        { }
        public Remainder(INumber a, int b) : this(a, new Number(b))
        { }
        public Remainder(INumber a, INumber b)
        {
            _a = a;
            _b = b;
        }
        public int Value()
        {
            return mod(_a.Value(), _b.Value());
        }
    }
}
