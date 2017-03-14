using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class MRZ
    {
        private readonly string _documentNumber;
        private readonly DateTime _dateOfBirth;
        private readonly DateTime _dateOfExpiry;
        private string _dateFormat = "{0}{1}{2}";
        public MRZ(
                string documentNumber,
                DateTime dateOfBirth,
                DateTime dateOfExpiry
            )
        {
            this._dateOfBirth = dateOfBirth;
            this._dateOfExpiry = dateOfExpiry;
            this._documentNumber = documentNumber;
        }

        public string Info()
        {
            return String.Format(
                    "{0}{1}{2}",
                    this._documentNumber,
                    this._dateOfBirth.ToString(),
                    this._dateOfExpiry.ToString()
                );
        }
    }
}
