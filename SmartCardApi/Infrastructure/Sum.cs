using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartCardApi.Infrastructure
{
    public class Sum : INumber
    {
        private readonly IEnumerable<INumber> _numbers;
        private readonly Func<int, int, int> plus = (a, b) => a + b;

        public Sum(IEnumerable<INumber> numbers)
        {
            _numbers = numbers;
        }
        public Sum(int a, INumber b) : this(new Number(a), b)
        { }
        public Sum(INumber a, int b) : this(a, new Number(b))
        { }
        public Sum(INumber a, INumber b)
            : this(new List<INumber>() {a, b})
        {
        }
        public int Value()
        {
            return _numbers.Aggregate(
                        0,
                        (prev, next) => plus(prev, next.Value())
                   );
        }
    }
}
