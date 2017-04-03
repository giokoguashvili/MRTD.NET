using System.Linq;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.SecureMessaging.Pipe
{
    public class ReadedBytesRange : IBinary
    {
        private readonly INumber _startByteIntex;
        private readonly INumber _bytesCountForRead;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _selfIncrementSsc;
        private readonly IReader _reader;

        public ReadedBytesRange(
                INumber startByteIntex,
                INumber bytesCountForRead,
                IBinary kSenc,
                IBinary kSmac,
                IBinary selfIncrementSsc,
                IReader reader
            )
        {
            _startByteIntex = startByteIntex;
            _bytesCountForRead = bytesCountForRead;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _selfIncrementSsc = selfIncrementSsc;
            _reader = reader;
        }
        public byte[] Bytes()
        {
            return new DecryptedProtectedResponseApdu(
                       new Cached(
                           new VerifiedProtectedResponseApdu(
                               new Cached(
                                   new ExecutedCommandApdu(
                                       new ProtectedCommandApdu(
                                            new Cached(
                                                new ReadBinaryCommandApdu(_startByteIntex, _bytesCountForRead)
                                            ),
                                            _kSenc,
                                            _kSmac,
                                            new Cached(_selfIncrementSsc.Bytes())
                                        ),
                                       _reader
                                   )
                               ),
                               new Cached(_selfIncrementSsc.Bytes()),
                               _kSmac
                           )
                       ),
                       _kSenc
                   )
                   .Bytes()
                   .Take(_bytesCountForRead.Value())
                   .ToArray();
        }
    }
}
