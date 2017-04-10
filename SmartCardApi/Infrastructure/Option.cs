using System.Collections;
using System.Collections.Generic;

namespace SmartCardApi.Infrastructure
{
    public class Option<T> : IOption<T>
    {
        private readonly T[] _data;
        private readonly IEnumerator<T> _enumerator;

        public Option(T element)
            : this(new OptionEnumerator<T>(element))
        { }

        public Option()
            : this(new OptionEnumerator<T>())
        { }

        public Option(OptionEnumerator<T> opt)
        {
            _enumerator = opt.GetEnumerator();
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }

        public T Current { get { return _enumerator.Current; } }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
