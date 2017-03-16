using HelloWord.Cryptography;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.APDU
{
    public class ResponseAPDU : IResponseAPDU, IBinary
    {
        private readonly ResponseApdu _parsedResposne;
        public ResponseAPDU(ICommandAPDU executedCommandAPDU)
        {
            this._parsedResposne = new ResponseApdu(
                   executedCommandAPDU.Bytes(),
                   executedCommandAPDU.IsoCase(),
                   executedCommandAPDU.ActiveProtocol()
               );
        }

        public IBinary Body()
        {
            return new Binary(this._parsedResposne.GetData());
        }

        public byte[] Bytes()
        {
            return this._parsedResposne.FullApdu;
        }

        public IBinary Trailer()
        {
            return new Binary(new byte[] 
            {
                this._parsedResposne.SW1,
                this._parsedResposne.SW2
            });
        }
    }
}
