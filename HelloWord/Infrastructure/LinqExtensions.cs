using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> TakeWhileWithIncludingLast<T>(this IEnumerable<T> data, Func<T, bool> predicate)
        {
            foreach (var item in data)
            {
                yield return item;
                if (!predicate(item))
                    break;
            }
        }
    }
}
