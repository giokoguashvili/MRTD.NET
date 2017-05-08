using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.CommandAPDU.Header
{
    public class CommandApduHeader : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandApduHeader(IBinary rawCommandApdu)
        {
            _rawCommandApdu = rawCommandApdu;
        }
        public byte[] Bytes()
        {
            return _rawCommandApdu
                .Bytes()
                .Take(4)
                .ToArray();
        }
    }
}
