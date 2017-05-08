using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.ISO7816.CommandAPDU.Header;

namespace SmartCardApi.SecureMessaging
{
    public class MaskedCommandApduHeader : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public MaskedCommandApduHeader(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return new CombinedBinaries(
                new MaskedCLA(
                    new CLA(_commandApduHeader)
                ),
                new Binary(
                    _commandApduHeader
                        .Bytes()
                        .Skip(1)
                )
            ).Bytes();
        }
    }
}
