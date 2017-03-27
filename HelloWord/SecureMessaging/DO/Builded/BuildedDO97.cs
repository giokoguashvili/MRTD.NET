using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Body;

namespace HelloWord.SecureMessaging.DO
{
    public class BuildedDO97 : IBinary
    {
        private readonly IBinary _rawCommandApdu;
        public BuildedDO97(IBinary rawCommandApdu)
        {
            _rawCommandApdu = rawCommandApdu;
        }
        public byte[] Bytes()
        {
            var exceptedDataLength = new Hex(
                                        new Le(
                                            new CommandApduBody(_rawCommandApdu)
                                        )
                                     ).ToInt();

            //  If Le is not available, leave building DO ‘97’ out. 
            if (exceptedDataLength == 0)
            {
                return new Binary().Bytes();
            }

            return new ConcatenatedBinaries(
                        new BinaryHex("9701"),
                        new HexInt(exceptedDataLength)
                    ).Bytes();
        }
    }
}
