using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.CommandAPDU.Header
{
    public class P1 : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public P1(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Skip(2)
                .Take(1)
                .ToArray();
        }
    }
}
