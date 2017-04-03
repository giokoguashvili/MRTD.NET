using System.Linq;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.SecureMessaging.Pipe
{
    public class SecureMessagingPipe : IBinary
    {
        private readonly IBinary _fid;
        private readonly INumber _bytesCountForRead;
        private readonly IReader _securedReader;

        public SecureMessagingPipe(
                IBinary fid,
                INumber bytesCountForRead,
                IReader securedReader
            )
        {
            _fid = fid;
            _bytesCountForRead = bytesCountForRead;
            _securedReader = securedReader;
        }
        public byte[] Bytes()
        {
            _securedReader
                .Transmit(new SelectApplicationCommandApdu(_fid));
           
            var step = new Number(255);
            var range = Enumerable
                .Range(0, _bytesCountForRead.Value())
                .Where(index => index % step.Value() == 0)
                .Select(index => new
                {
                    StartIndex = new Number(index),
                    Count = new StepBytesCount(step, _bytesCountForRead, new Number(index))
                });

            return range
                    .Aggregate(
                        new byte[0],
                        (prev, next) => prev.Concat(
                                            _securedReader.Transmit(new ReadBinaryCommandApdu(next.StartIndex, next.Count))
                                            .Bytes()
                                        ).ToArray()
                        );
        }
    }
}
