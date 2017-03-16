using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.SmartCard
{
    public class DecryptedExternalAuthenticateRespData : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        public DecryptedExternalAuthenticateRespData(IBinary externalAuthRespData)
        {
            this._externalAuthRespData = externalAuthRespData;
        }
        public byte[] Bytes()
        {
            throw new NotImplementedException();
            //return new ExternalAuthenticateRespData(
            //        new ExternalAuthenticateCmdData(
            //            mrzInfoMy,
            //            new BinaryHex(
            //                new Hex(
            //                    new Binary(responseApdu1.GetData())
            //                ).AsString()
            //            )
            //        )
            //    );
        }
    }
}
