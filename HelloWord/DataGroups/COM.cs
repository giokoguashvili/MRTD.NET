using System;
using HelloWord.DataGroups.Content;
using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.DataGroups
{
    public class COM : IDataGroup<COMContent>
    {
        private readonly IBinary _cachedDgData;
        private readonly IBinary _fid = new BinaryHex("011E");
        public COM(IBacReader bacReader)
        {
            _cachedDgData = new Cached(bacReader.DGData(_fid));
        }
        public byte[] Bytes()
        {
            return _cachedDgData.Bytes();
        }

        public COMContent Content()
        {
            return new COMContent(_cachedDgData);
        }
    }
}
