using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.Pipe;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.DataGroups.DG
{
    public class DGData : IBinary
    {
        private readonly IBinary _fid;
        private readonly IReader _securedReader;
        public DGData(
                IBinary fid,
                IReader securedReader
            )
        {
            _fid = fid;
            _securedReader = securedReader;
        }
        public byte[] Bytes()
        {
            var cachedLen = new DGDataHexLength(
                _fid,
                _securedReader
            ).Value();
            return new SecureMessagingPipe(
                        _fid, 
                        new Number(cachedLen), 
                        _securedReader
                   )
                   .Bytes();
        }
    }
}
