using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.MRZ
{
    public class CheckedDigit : INumber
    {
        private readonly string _mrzInfoField;
        private readonly INumber _dividerNumber = new Number(10);
        public CheckedDigit(string mrzInfoField)
        {
            _mrzInfoField = mrzInfoField;
        }
        public int Value()
        {
            return new Remainder(
                        new Sum(
                           new Zipped(
                                new NumericalValues(_mrzInfoField),
                                new WeightingFigures(_mrzInfoField),
                                (a, b) => new Product(a, b)
                            )
                        ),
                        _dividerNumber
                   ).Value();
        }
    }
}
