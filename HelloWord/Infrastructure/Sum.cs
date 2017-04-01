using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Infrastructure
{
    public class Sum : INumber
    {
        private readonly INumber _a;
        private readonly INumber _b;
        private readonly Func<int, int, int> plus = (a, b) => a + b;
        public Sum(INumber a, INumber b)
        {
            _a = a;
            _b = b;
        }
        public int Value()
        {
            return plus(_a.Value(), _b.Value());
        }
    }
}
