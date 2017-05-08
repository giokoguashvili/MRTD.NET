using System.Collections;
using System.Collections.Generic;

namespace SmartCardApi.Infrastructure.Option
{
    public class Option<T> : IOption<T>
    {
        private IEnumerator<T> _enumerator;
        private readonly IEnumerable<T> _data;

        private IEnumerator<T> Enumerator
        {
            get { return _enumerator ?? (_enumerator = _data.GetEnumerator()); }
        }

        public Option(T element)
            : this(new [] { element })
        { }

        public Option()
            : this(new T[0])
        { }

        public Option(IEnumerable<T> data)
        {
            _data = data;
        }

        public void Dispose()
        {
            Enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }

        public void Reset()
        {
            Enumerator.Reset();
        }

        public T Current { get { return Enumerator.Current; } }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
