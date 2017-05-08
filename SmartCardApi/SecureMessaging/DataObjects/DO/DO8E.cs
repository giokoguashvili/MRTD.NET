using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging.DataObjects.DO
{
    public class DO8E : IBinary
    {
        private readonly IBinary _computedCc;
        private readonly IBinary _berTlvTag = new BinaryHex("8E");

        public DO8E(IBinary computedCC)
        {
            _computedCc = computedCC;
        }
        public byte[] Bytes()
        {
            // DO8E Format: [8E][EncodedDataLengh][EncodedData]
            var berTlvLen = new HexInt(
                                new BytesCount(_computedCc)
                            );
            return new CombinedBinaries(
                    _berTlvTag,
                    berTlvLen,
                    _computedCc
                ).Bytes();
        }
    }
}
