using System;
using System.Linq;
using SmartCardApi.Commands;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SecureMessaging.Pipe
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

            // http://www.cardwerk.com/smartcards/smartcard_standard_ISO7816-4_5_basic_organizations.aspx
            var step = new Number(230); // 255 not work
            var bytesCountForRead = _bytesCountForRead.Value();
            var range = Enumerable
                .Range(0, bytesCountForRead)
                .Where(index => index % step.Value() == 0)
                .Select(index => new
                {
                    StartIndex = new Number(index),
                    Count = new StepBytesCount(step, _bytesCountForRead, new Number(index))
                });
            var lis = range.Select(x => new {start = x.StartIndex.Value(), count = x.Count.Value()});
            Console.WriteLine("{0}", lis.Sum(x => x.count));
            return range
                    .Aggregate(
                        new byte[0],
                        (prev, next) =>
                        {
                            Console.WriteLine("{0} - {1}", next.StartIndex.Value(), next.Count.Value());
                            return prev.Concat(
                                _securedReader.Transmit(new ReadBinaryCommandApdu(next.StartIndex, next.Count))
                                    .Bytes()
                            ).ToArray();
                        });
        }
    }
}
