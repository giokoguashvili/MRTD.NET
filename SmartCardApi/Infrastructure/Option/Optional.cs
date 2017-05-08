using System.Collections;
using System.Collections.Generic;

namespace SmartCardApi.Infrastructure.Option
{
    public abstract class Optional<T> : IEnumerable<T>
    {

        public abstract IOption<T> Content();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Content();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Content();
        }
    }
}
