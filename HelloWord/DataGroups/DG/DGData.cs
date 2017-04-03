using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.Pipe;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.DataGroups.DG
{
    public class DGData : IBinary
    {

        private readonly IBinary _cachedSecureMessagingPipe;
        public DGData(
                IBinary fid,
                IReader securedReader
            )
        {
            _cachedSecureMessagingPipe = new Cached(
                                            new SecureMessagingPipe(
                                                    fid,
                                                    new DGDataHexLength(
                                                        fid,
                                                        securedReader
                                                    ),
                                                    securedReader
                                               )
                                           );
        }
        public byte[] Bytes()
        {
            return _cachedSecureMessagingPipe.Bytes();
        }
    }
}
