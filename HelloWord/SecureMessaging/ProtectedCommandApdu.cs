using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApdu : IBinary
    {
        private readonly IBinary _rawCommandApduHeader;
        private readonly IBinary _DO8E;
        private readonly IBinary _DO87;
        private readonly byte[] _commandDataLength = new byte[] { 0x15 }; //21 len(DO8E) + len(DO87)
        private readonly byte[] _exceptedDataLength = new byte[] { 0x00 }; 

        public ProtectedCommandApdu(
                IBinary rawCommandApduHeader,
                IBinary do8e,
                IBinary do87
            )
        {
            _rawCommandApduHeader = rawCommandApduHeader;
            _DO8E = do8e;
            _DO87 = do87;
        }
        public byte[] Bytes()
        {
            return _rawCommandApduHeader
                .Bytes()
                .Concat(_commandDataLength)
                .Concat(
                    _DO87
                        .Bytes()
                        .Concat(_DO8E.Bytes())
                )
                .Concat(_exceptedDataLength)
                .ToArray();
        }
    }
}
