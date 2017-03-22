using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ConstructedProtectedCommandApdu : IBinary
    {
        private readonly IBinary _maskedCommandApduHeader;
        private readonly IBinary _do87;
        private readonly IBinary _do8E;
        private readonly byte[] _commandDataLength = new byte[] { 0x15 }; //21 len(DO8E) + len(DO87)
        private readonly byte[] _exceptedDataLength = new byte[] { 0x00 };

        public ConstructedProtectedCommandApdu(
              IBinary rawCommandApduHeader,
              IBinary do87,
              IBinary do8e
          )
        {
            _maskedCommandApduHeader = rawCommandApduHeader;
            _do87 = do87;
            _do8E = do8e;
        }
        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                    _maskedCommandApduHeader,
                    new Binary(_commandDataLength),
                    new ConcatenatedBinaries(
                        _do87,
                        _do8E
                    ),
                    new Binary(_exceptedDataLength)
                ).Bytes();
        }
    }
}
