using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.MRZ
{
    public class WeightingFigure : INumber
    {
        private readonly INumber _mrzDataElementIndex;
        private readonly int[] _weightingNumbers = new[] { 7, 3, 1 };
        public WeightingFigure(INumber mrzDataElementIndex)
        {
            _mrzDataElementIndex = mrzDataElementIndex;
        }
        public int Value()
        {
            return _weightingNumbers[_mrzDataElementIndex.Value() % 3];
        }
    }
}
