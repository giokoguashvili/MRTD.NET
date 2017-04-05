using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.Infrastructure
{
    public class Product : INumber
    {
        private readonly IEnumerable<INumber> _numbers;
        private readonly INumber _a;
        private readonly INumber _b;
        private readonly Func<int, int, int> multiply = (a, b) => a * b;

        public Product(int a, int b) : this(new Number(a), new Number(b))
        { }
        public Product(int a, INumber b) : this(new Number(a), b)
        { }
        public Product(INumber a, int b) : this(a, new Number(b))
        { }
        public Product(INumber a, INumber b)
            : this(new List<INumber>() { a, b })
        { }

        public Product(IEnumerable<INumber> numbers)
        {
            _numbers = numbers;
        }

        public int Value()
        {
            return _numbers.Aggregate(
                        new Number(1),
                        (prev, next) => new Number(multiply(prev.Value(), next.Value()))
                   ).Value();
        }
    }
}
