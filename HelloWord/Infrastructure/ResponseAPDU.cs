using HelloWord.CommandAPDU;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{
    public class ResponseAPDU : IResponseAPDU, IBinary
    {
        private readonly ResponseApdu _parsedResposne;
        public ResponseAPDU(ICommandAPDU executedCommandAPDU)
        {
            this._parsedResposne = new ResponseApdu(
                   executedCommandAPDU.Bytes(),
                   executedCommandAPDU.Case(),
                   executedCommandAPDU.Protocol()
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
