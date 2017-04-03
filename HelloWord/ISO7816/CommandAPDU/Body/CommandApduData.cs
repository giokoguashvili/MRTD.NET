using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.CommandAPDU.Body
{
    public class CommandApduData : IBinary
    {
        private readonly IBinary _commandApduBody;

        public CommandApduData(IBinary commandApduBody)
        {
            _commandApduBody = commandApduBody;
        }
        public byte[] Bytes()
        {
            var commandDataLength = new IntHex(
                                        new Lc(_commandApduBody)
                                    ).Value();
            return _commandApduBody
                .Bytes()
                .Skip(1)
                .Take(commandDataLength)
                .ToArray();
        }
    }
}
