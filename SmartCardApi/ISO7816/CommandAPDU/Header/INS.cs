using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.ISO7816.CommandAPDU.Header
{
    public class INS : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public INS(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }

        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Skip(1)
                .Take(1)
                .ToArray();
        }
    }
}
