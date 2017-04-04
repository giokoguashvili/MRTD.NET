using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging.DataObjects.DO
{
    public class DO97 : IBinary
    {
        private readonly int _exceptedDataLength;
        private readonly IBinary _berTlvTag = new BinaryHex("97");
        private readonly IBinary _berTlvLen = new BinaryHex("01");
        public DO97(int exceptedDataLength)
        {
            _exceptedDataLength = exceptedDataLength;
        }
        public byte[] Bytes()
        {
            // DO97 Format [97][01][ExceptedDataLength] 
            return new CombinedBinaries(
                        _berTlvTag,
                        _berTlvLen,
                        new HexInt(_exceptedDataLength)
                    ).Bytes();
        }
    }
}
