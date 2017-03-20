using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Header
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
