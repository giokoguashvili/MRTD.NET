using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging.DataObjects.DO
{
    public class DO87 : IBinary
    {

        private readonly IBinary _berTlvTag = new BinaryHex("87");
        private readonly IBinary _berTlvValFirstByte = new BinaryHex("01");
        private readonly IBinary _encryptedData;
        public DO87(IBinary encryptedData)
        {
            _encryptedData = encryptedData;
        }
        public byte[] Bytes()
        {
            // DO87 Format: [87][EncryptedDataLength + 1][01][EncryptedData]
            var berTlvVal = new CombinedBinaries(
                                _berTlvValFirstByte,
                                _encryptedData
                             );
            var berTlvLen = new HexInt(
                                new BytesCount(berTlvVal)
                            );
            return new CombinedBinaries(
                        _berTlvTag,
                        berTlvLen,
                        berTlvVal
                    ).Bytes();
        }
    }
}
