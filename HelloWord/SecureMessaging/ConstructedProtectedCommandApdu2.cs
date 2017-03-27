using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using PCSC.Iso7816;

namespace HelloWord.SecureMessaging
{
    public class ConstructedProtectedCommandApdu2 : IBinary
    {
        private readonly IBinary _maskedCommandApduHeader;
        private readonly IBinary _do87;
        private readonly IBinary _do97;
        private readonly IBinary _do8e;
        private readonly byte[] _exceptedDataLength = new byte[] { 0x00 };

        public ConstructedProtectedCommandApdu2(
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
            var commandData = new ConcatenatedBinaries(
                                    _do87,
                                    _do97,
                                    _do8e
                                );

            var commandDataLengthAsBinaryHex = new HexInt(
                                                    commandData
                                                        .Bytes()
                                                        .Count()
                                               );

            return new ConcatenatedBinaries(
                    _maskedCommandApduHeader,
                    commandDataLengthAsBinaryHex,
                    commandData,
                    new Binary(_exceptedDataLength)
                ).Bytes();
        }
    }
}
