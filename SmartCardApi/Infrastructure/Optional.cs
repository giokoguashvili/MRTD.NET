using System.Collections;
using System.Collections.Generic;

namespace SmartCardApi.Infrastructure
{
    public abstract class Optional<T> : IEnumerable<T>
    {

        public abstract IOption<T> GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
