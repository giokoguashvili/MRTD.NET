using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard
{
    public class DecryptedExternalAuthenticateResponseData : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        public DecryptedExternalAuthenticateResponseData(
                IBinary externalAuthRespData
            )
        {
            this._externalAuthRespData = externalAuthRespData;
        }
        public byte[] Bytes()
        {
            throw new NotImplementedException();
            //return new TripleDES(
                    
            //    )
            //    .Decrypted()
            //    .Bytes();
        }
    }
}
