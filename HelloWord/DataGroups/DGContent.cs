using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;

namespace HelloWord.DataGroups
{
    public class DGContent : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly IReader _reader;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        public DGContent(
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
                            new DGContentHexLength(
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
