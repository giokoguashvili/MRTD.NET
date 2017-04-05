using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.MRZ
{
    public class WeightingFigures : IEnumerable<INumber>
    {
        private readonly string _mrzInfoField;

        public WeightingFigures(string mrzInfoField)
        {
            _mrzInfoField = mrzInfoField;
        }
        public IEnumerator<INumber> GetEnumerator()
        {
            for (int index = 0; index < _mrzInfoField.Length; index++)
            {
                yield return new WeightingFigure(new Number(index));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
