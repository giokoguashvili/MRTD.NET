using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.ISO7816.ResponseAPDU.Trailer;

namespace HelloWord.ISO7816.ResponseAPDU
{
    public class ResponseApdu : IResponseApdu
    {
        private readonly IBinary _executedCommandApdu;

        public ResponseApdu(IBinary executedCommandApdu)
        {
            _executedCommandApdu = executedCommandApdu;
        }
        public IBinary Body()
        {
            return new ResponseApduData(_executedCommandApdu);
        }

        public IBinary Trailer()
        {
            return new ResponseApduTrailer(_executedCommandApdu);
        }
    }
}
