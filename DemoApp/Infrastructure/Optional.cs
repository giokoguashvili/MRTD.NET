using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure
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
