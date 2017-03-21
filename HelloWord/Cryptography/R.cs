using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;

namespace HelloWord.Cryptography
{
    public class R : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        private readonly string _mrzInformation;

        public R(
                IBinary externalAuthRespData,
                string mrzInformation
            )
        {
            _externalAuthRespData = externalAuthRespData;
            _mrzInformation = mrzInformation;
        }
        public byte[] Bytes()
        {
            return new DecryptedExternalAuthenticateResponseData(
                    _externalAuthRespData,
                    _mrzInformation
                ).Bytes();
        }
    }
}
