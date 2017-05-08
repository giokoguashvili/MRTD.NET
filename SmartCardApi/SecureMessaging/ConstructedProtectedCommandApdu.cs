using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public class ConstructedProtectedCommandApdu : IBinary
    {
        private readonly IBinary _maskedCommandApduHeader;
        private readonly IBinary _do87;
        private readonly IBinary _do97;
        private readonly IBinary _do8e;
        private readonly byte[] _exceptedDataLength = new byte[] { 0x00 };

        public ConstructedProtectedCommandApdu(
              IBinary rawCommandApduHeader,
              IBinary do87,
              IBinary do97,
              IBinary do8e
          )
        {
            _maskedCommandApduHeader = rawCommandApduHeader;
            _do87 = do87;
            _do97 = do97;
            _do8e = do8e;
        }
        public byte[] Bytes()
        {
            var commandData = new CombinedBinaries(
                                    _do87,
                                    _do97,
                                    _do8e
                                );

            var commandDataLengthAsBinaryHex = new HexInt(
                                                    commandData
                                                        .Bytes()
                                                        .Count()
                                               );
            return new CombinedBinaries(
                    _maskedCommandApduHeader,
                    commandDataLengthAsBinaryHex,
                    commandData,
                    new Binary(_exceptedDataLength)
                ).Bytes();
        }
    }
}
