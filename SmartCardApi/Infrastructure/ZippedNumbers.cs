using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.Infrastructure
{

    public class Zipped : IEnumerable<INumber>
    {
        private readonly INumber[] _aNums;
        private readonly INumber[] _bNums;
        private readonly Func<INumber, INumber, INumber> _ziper;

        public Zipped(IEnumerable<INumber> aNums, IEnumerable<INumber> bNums, Func<INumber, INumber, INumber> ziper)
            : this(aNums.ToArray(), bNums.ToArray(), ziper)
        {}
        public Zipped(INumber[] aNums, INumber[] bNums, Func<INumber, INumber, INumber> ziper)
        {
            _aNums = aNums;
            _bNums = bNums;
            _ziper = ziper;
        }
        public IEnumerator<INumber> GetEnumerator()
        {
            for (int index = 0; index < _aNums.Count(); index++)
            {
                yield return new Number(_ziper(_aNums[index], _bNums[index]).Value());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
