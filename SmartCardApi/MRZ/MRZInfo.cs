using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.MRZ
{
    public class MRZInfo : ISymbols
    {
        private readonly string _serialNumber;
        private readonly DateTime _dateOfBirth;
        private readonly DateTime _dateOfExpiry;
        public MRZInfo(
                string serialNumber,
                DateTime dateOfBirth,
                DateTime dateOfExpiry
            )
        {
            _serialNumber = serialNumber;
            _dateOfBirth = dateOfBirth;
            _dateOfExpiry = dateOfExpiry;
        }

        public override string ToString()
        {
            var formatedDateOfBirth = _dateOfBirth.ToString(new MRZDateFormat().ToString());
            var formatedDateOfExpiry = _dateOfExpiry.ToString(new MRZDateFormat().ToString());
            return String.Concat(
                _serialNumber,
                new CheckedDigit(_serialNumber).Value(),
                formatedDateOfBirth,
                new CheckedDigit(formatedDateOfBirth).Value(),
                formatedDateOfExpiry,
                new CheckedDigit(formatedDateOfExpiry).Value()
            );
        }
    }
}
