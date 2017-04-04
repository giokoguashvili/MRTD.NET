using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SecureMessaging
{
    public class ExecutedCommandApdu : IBinary
    {
        private readonly IBinary _rawCommandApdu;
        private readonly IReader _reader;
        public ExecutedCommandApdu(
                IBinary rawCommandApdu,
                IReader reader
            )
        {
            _rawCommandApdu = rawCommandApdu;
            _reader = reader;
        }

        public byte[] Bytes()
        {
            return _reader
                        .Transmit(_rawCommandApdu)
                        .Bytes();
        }
    }
}
