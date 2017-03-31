using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;

namespace HelloWord.DataGroups.DG
{
    public class DGData : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly IReader _reader;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        public DGData(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
            _reader = reader;
        }
        public byte[] Bytes()
        {
            return new SecureMessagingPipe(
                        _applicationIdentifier,
                        new Hex(
                            new DGDataHexLength(
                                _applicationIdentifier,
                                _kSenc,
                                _kSmac,
                                _ssc,
                                _reader
                            )
                        ).ToInt(),
                        _kSenc,
                        _kSmac,
                        _ssc,
                        _reader
                   )
                   .Bytes();
        }
    }
}
