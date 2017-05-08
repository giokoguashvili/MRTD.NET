using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public class ProtectedCommandApduHeader : IBinary
    {
        private readonly IBinary _commandApduHeader;
        public ProtectedCommandApduHeader(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;

        }
        public byte[] Bytes()
        {
            return new Padded(
                        new MaskedCommandApduHeader(_commandApduHeader)
                     ).Bytes();
        }
    }
}
