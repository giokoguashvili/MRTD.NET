using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using PCSC.Iso7816;

namespace HelloWord.SmartCard
{
    public class ComSelectApplication 
    {
        private readonly IBinary _reader;
        public ComSelectApplication(IBinary reader)
        {

        }

        public byte[] Binary()
        {
            throw new NotImplementedException();
            //return new ResponseApdu(
            //        this._reader.Binary(),
            //        IsoCase.Case3Short,
            //        this._reader.Protocol()
            //    ).GetData();
        }
    }
}
