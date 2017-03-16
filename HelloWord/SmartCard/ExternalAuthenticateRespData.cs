using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.SmartCard
{
    public class ExternalAuthenticateRespData : IBinary
    {
        private readonly IBinary _externalAuthCmdData;
        public ExternalAuthenticateRespData(IBinary respData)
        {
           // this._externalAuthCmdData = externalAuthCmdData;
        }
        public byte[] Bytes()
        {
            throw new NotImplementedException();
        }
    }
}
