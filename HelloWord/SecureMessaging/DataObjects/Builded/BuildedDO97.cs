using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Body;
using HelloWord.SecureMessaging.DataObjects.DO;

namespace HelloWord.SecureMessaging.DataObjects.Builded
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
            var exceptedDataLength = new IntHex(
                                        new Le(
                                            new CommandApduBody(_rawCommandApdu)
                                        )
                                     ).Value();
            //  If Le is not available, leave building DO ‘97’ out. 
            if (exceptedDataLength == 0)
            {
                return new Binary().Bytes();
            }

            return new DO97(exceptedDataLength).Bytes();
        }
    }
}
