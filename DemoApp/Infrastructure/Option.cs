using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure
{
    public class OptionEnumerator<T> : IEnumerable<T>
    {
        private readonly T[] _data;

        public OptionEnumerator(T element)
            : this(new T[] { element })
        {
        }

        public OptionEnumerator()
            : this(new T[0])
        { }

        public OptionEnumerator(T[] data)
        {
            _data = data;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) _data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

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
