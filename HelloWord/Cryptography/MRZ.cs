using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class MRZ
    {
        private readonly string _documentNumber;
        private readonly string _dateOfBirth;
        private readonly string _dateOfExpiry;
        public MRZ()
        {

        }

        public string Info()
        {
            return String.Format(
                    "{0}{1}{2}",
                    this._documentNumber,
                    this._dateOfBirth,
                    this._dateOfExpiry
                );
        }
    }
}
