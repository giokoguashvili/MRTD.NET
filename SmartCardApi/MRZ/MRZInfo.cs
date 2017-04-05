using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.MRZ
{
    public class MRZInfo 
    {
        private readonly string _serialNumber;
        private readonly DateTime _dateOfBirth;
        private readonly DateTime _dateOfExpiry;
        private readonly string _dateFormat = "yyMMdd";

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
            var formatedDateOfBirth = _dateOfBirth.ToString(_dateFormat);
            var formatedDateOfExpiry = _dateOfExpiry.ToString(_dateFormat);
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
