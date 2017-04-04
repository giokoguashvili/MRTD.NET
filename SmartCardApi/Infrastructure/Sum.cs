using System;

namespace SmartCardApi.Infrastructure
{
    public class Sum : INumber
    {
        private readonly INumber _a;
        private readonly INumber _b;
        private readonly Func<int, int, int> plus = (a, b) => a + b;
        public Sum(int a, INumber b) : this(new Number(a), b)
        { }
        public Sum(INumber a, int b) : this(a, new Number(b))
        { }
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
