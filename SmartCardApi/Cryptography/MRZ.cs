using System;

namespace SmartCardApi.Cryptography
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
            _dateOfBirth = dateOfBirth;
            _dateOfExpiry = dateOfExpiry;
            _documentNumber = documentNumber;
        }

        public string Info()
        {
            return String.Format(
                    "{0}{1}{2}",
                    _documentNumber,
                    _dateOfBirth,
                    _dateOfExpiry
                );
        }
    }
}
