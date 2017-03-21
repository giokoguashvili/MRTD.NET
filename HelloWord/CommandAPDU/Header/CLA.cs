using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Header
{
    public class CLA : IBinary
    {
        private readonly IBinary _commandApduHeader;
        public CLA(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Take(1)
                .ToArray();
        }
    }
}
