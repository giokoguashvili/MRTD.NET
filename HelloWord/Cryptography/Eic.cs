using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Eic : IBinary
    {
        private readonly IBinary _externalAuthenticateResponseData;

        public Eic(IBinary externalAuthenticateResponseData)
        {
            _externalAuthenticateResponseData = externalAuthenticateResponseData;
        }
        public byte[] Bytes()
        {
            return _externalAuthenticateResponseData
                .Bytes()
                .Take(32)
                .ToArray();
        }
    }
}
