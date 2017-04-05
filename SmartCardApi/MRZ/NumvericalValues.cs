using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.MRZ
{
    public class NumericalValues : IEnumerable<INumber>
    {
        private readonly string _mrzInfoField;

        public NumericalValues(string mrzInfoField)
        {
            _mrzInfoField = mrzInfoField;
        }
        public IEnumerator<INumber> GetEnumerator()
        {
            foreach (var dataElement in _mrzInfoField)
            {
                yield return new NumericalData(dataElement);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
