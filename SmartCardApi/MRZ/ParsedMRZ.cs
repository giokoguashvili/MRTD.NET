using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.MRZ
{

    public class ParsedMRZ
    {
        private readonly IBinary _hexMrz;
        public ParsedMRZ(string mrz)
            : this(new BinaryHex(mrz))
        { }
        public ParsedMRZ(IBinary hexMRZ)
        {
            _hexMrz = hexMRZ;
        }

        public string Data
        {
            get { return new ASCIIString(_hexMrz).ToString(); }
        }
        public string DocumentCode
        {
            get { return new ASCIIString(_hexMrz.Bytes().Take(2)).ToString(); }
        }

        public string IssuingStateOrOrganization
        {
            get { return new ASCIIString(_hexMrz.Bytes().Skip(2).Take(3)).ToString(); }
        }
        public string DocumentNumber
        {
            get { return new ASCIIString(_hexMrz.Bytes().Skip(5).Take(9)).ToString(); }
        }
        public int DocumentNumberCheckDigit
        {
            get
            {
                return new IntString(
                                new ASCIIString(
                                    _hexMrz
                                        .Bytes()
                                        .Skip(14)
                                        .Take(1)
                                    ).ToString()
                                ).Value();
            }
        }
        public string DocumentNumberWithOptionalData
        {
            get { return new ASCIIString(_hexMrz.Bytes().Skip(15).Take(15)).ToString(); }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return
                    DateTime.ParseExact(
                                new ASCIIString(_hexMrz.Bytes().Skip(30).Take(6)).ToString(),
                                new MRZDateFormat().ToString(),
                                null
                            );
            }
        }
        public int DateOfBirthCheckDigit
        {
            get
            {
                return new IntString(
                            new ASCIIString(
                                _hexMrz
                                    .Bytes()
                                    .Skip(36)
                                    .Take(1)
                            ).ToString()
                        ).Value();
            }
        }

        public string Sex
        {
            get
            {
                return new Sex(
                            new ASCIIString(
                                _hexMrz
                                    .Bytes()
                                    .Skip(37)
                                    .Take(1)
                            ).ToString()
                       ).ToString();
            }
        }

        public DateTime DateOfExpiry
        {
            get
            {
                return
                    DateTime.ParseExact(
                                new ASCIIString(_hexMrz.Bytes().Skip(38).Take(6)).ToString(),
                                new MRZDateFormat().ToString(),
                                null
                            );
            }
        }
        public int DateOfExpiryCheckDigit
        {
            get
            {
                return new IntString(
                            new ASCIIString(
                                _hexMrz
                                    .Bytes()
                                    .Skip(44)
                                    .Take(1)
                            ).ToString()
                        ).Value();
            }
        }
        public string Nationality
        {
            get
            {
                return new ASCIIString(
                            _hexMrz
                                .Bytes()
                                .Skip(45)
                                .Take(3)
                        ).ToString();
            }
        }
        public string Optionaldata
        {
            get
            {
                return new ASCIIString(
                            _hexMrz
                                .Bytes()
                                .Skip(48)
                                .Take(11)
                        ).ToString();
            }
        }
        public int CompositeCheckDigit
        {
            get
            {
                return new IntString(
                            new ASCIIString(
                                _hexMrz
                                    .Bytes()
                                    .Skip(59)
                                    .Take(1)
                            ).ToString()
                        ).Value();
            }
        }
        public string NameOfHolder
        {
            get
            {
                return new ASCIIString(
                            _hexMrz
                                .Bytes()
                                .Skip(60)
                                .Take(30)
                        ).ToString();
            }
        }

    }
}
