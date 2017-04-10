using System.Collections;
using System.Collections.Generic;

namespace SmartCardApi.Infrastructure
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
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
