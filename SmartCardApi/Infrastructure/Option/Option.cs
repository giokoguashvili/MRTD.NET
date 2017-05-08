using System.Collections;
using System.Collections.Generic;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure.Option
{
    public class Option<T> : IOption<T>
    {
        private readonly ICache<IEnumerator<T>> _cachedEnumerator;

        public Option(T element)
            : this(new [] { element })
        { }

        public Option()
            : this(new T[0])
        { }

        public Option(IEnumerable<T> data)
        {
            _cachedEnumerator = new Cache<IEnumerator<T>>(data.GetEnumerator);
        }

        public void Dispose()
        {
            _cachedEnumerator.Content().Dispose();
        }

        public bool MoveNext()
        {
            return _cachedEnumerator.Content().MoveNext();
        }

        public void Reset()
        {
            _cachedEnumerator.Content().Reset();
        }

        public T Current { get { return _cachedEnumerator.Content().Current; } }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _cachedEnumerator.Content();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
